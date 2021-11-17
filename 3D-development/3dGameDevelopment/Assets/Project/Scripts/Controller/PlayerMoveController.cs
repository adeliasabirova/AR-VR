using UnityEngine;

namespace Project
{
    internal static class GetMovementByPlayer
    {
        public static PlayerMoveController Controller { get; set; }
        public static void AnimatorMove(float deltaTime)
        {
            Controller.AnimatorMove(deltaTime);
        }

    }
    internal sealed class PlayerMoveController: IInitialize, IExecute, ICleanUp, IAnimatorMove
    {
        private Transform _playerTransform;
        private readonly PlayerBodyData _playerData;
        private float _horizontal;
        private float _vertical;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private Camera _camera;
        private MovementTranslation _movement;
        private Animator _animator;
        private float _distanceToGroundCheck;
        private const float _coefficientHalfForLegs = 0.5f;
        private bool _onGround;
        private bool _jump;
        private IUserButtonInputProxy _jumpInputProxy;
        private JumpMovement _jumpMovement;
        private Rigidbody _body;


        public PlayerMoveController(Transform playerTransform, PlayerBodyData playerData, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX, IUserButtonInputProxy inputJump) input, Camera camera)
        {
            _playerTransform = playerTransform;
            _playerData = playerData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _jumpInputProxy = input.inputJump;
            _camera = camera;
            
        }

        public void Initialize()
        {
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisChange;
            _jumpInputProxy.MouseButtonOnChangeDown += MouseButtonOnChangeDown;

            _distanceToGroundCheck = _playerData.DistanceToGroundCheck;

            _animator = _playerTransform.GetComponent<Animator>();
            _body = _playerTransform.GetComponent<Rigidbody>();

            _movement = new MovementTranslation();            
            _jumpMovement = new JumpMovement(_body, _distanceToGroundCheck);
        }


        private void VerticalOnAxisChange(float obj)
        {
            _vertical = obj;
        }

        private void HorizontalOnAxisChange(float obj)
        {
            _horizontal = obj;
        }

        private void MouseButtonOnChangeDown(bool obj)
        {
            _jump = obj;
        }

        private Vector3 GroundCheck()
        {
            RaycastHit hitInfo;
#if UNITY_EDITOR
            Debug.DrawLine(_playerTransform.position + (Vector3.up * 0.1f), _playerTransform.position + (Vector3.up * 0.1f) + (Vector3.down * _distanceToGroundCheck));
#endif
            if (Physics.Raycast(_playerTransform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, _distanceToGroundCheck))
            {
                _animator.applyRootMotion = true;
                _onGround = true;
                return hitInfo.normal;
            }
            else
            {
                _animator.applyRootMotion = false;
                _onGround = false;
                return Vector3.up;
            }
        }

        private void ApplyExtraTurnRotation(float forward, float turn, float deltaTime)
        {
            float turnVelocity = Mathf.Lerp(_playerData.StandingTurningSpeed, _playerData.MovingTurningSpeed, forward);
            _playerTransform.Rotate(0.0f, turn * turnVelocity * deltaTime, 0.0f);
            Debug.Log(_playerTransform.rotation.eulerAngles);
            Debug.Log(turn);
            Debug.Log(forward);
        }

        private void UpdateAnimator(float forward, float turn, float deltaTime)
        {
            _animator.SetFloat(AnimatorManager.Forward, forward, 0.1f, deltaTime);
            _animator.SetFloat(AnimatorManager.Turn, turn, 0.1f, deltaTime);
            _animator.SetBool(AnimatorManager.Ground, _onGround);
            if (!_onGround)
                _animator.SetFloat(AnimatorManager.Jump, _body.velocity.y);

            float legCycle = Mathf.Repeat(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime + _playerData.RunningCycleLegOffset, 1);
            float jumpLeg = (legCycle < _coefficientHalfForLegs ? 1 : -1) * forward;

            if (_onGround)
                _animator.SetFloat(AnimatorManager.JumpLeg, jumpLeg);
        }

        private void StartToJump()
        {
            if (_jump && _animator.GetCurrentAnimatorStateInfo(0).IsName(AnimatorManager.Ground))
            {
                var direction = new Vector3(_body.velocity.x, _playerData.Power, _body.velocity.z);
                _distanceToGroundCheck = _jumpMovement.JumpOnGround(direction);
                _onGround = false;
                _animator.applyRootMotion = false;
            }
        }

        public void Execute(float deltaTime)
        {
            if (_vertical != 0)
                Debug.Log("forward");

            _movement.Move(_horizontal, _vertical, _camera.transform.right, _camera.transform.forward);
            
            var translation = _playerTransform.InverseTransformDirection(_movement.Speed);
            var groundNormal = GroundCheck();
            translation = Vector3.ProjectOnPlane(translation, groundNormal);
            var turningValue = Mathf.Atan2(translation.x, translation.z);
            var forwardValue = translation.z;

            ApplyExtraTurnRotation(forwardValue, turningValue, deltaTime);

            if (_onGround)
                StartToJump();
            else
                _distanceToGroundCheck = _jumpMovement.JumpAtAir(_playerData.GravityMultiplier);

            UpdateAnimator(forwardValue, turningValue, deltaTime);

            if (_onGround && translation.magnitude > 0)
                _animator.speed = _playerData.AnimatorSpeedMultiplier;
            else
                _animator.speed = 1;
            
        }

        public void AnimatorMove(float deltaTime)
        {
            if(_onGround && deltaTime > 0)
            {
                Vector3 velocity = _animator.deltaPosition * _playerData.MovingSpeedMultiplier / deltaTime;
                velocity.y = _body.velocity.y;
                _body.velocity = velocity;
            }
        }

        public void CleanUp()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisChange;
            _jumpInputProxy.MouseButtonOnChangeDown -= MouseButtonOnChangeDown;
        }
    }
}

