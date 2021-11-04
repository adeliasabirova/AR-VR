using UnityEngine;

namespace Project
{
    internal sealed class PlayerMoveController: IInitialize, IExecute, ICleanUp
    {
        private readonly Transform _playerTransform;
        private readonly PlayerBodyData _playerData;
        private float _horizontal;
        private float _vertical;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private Camera _camera;
        private Movement _movement;


        public PlayerMoveController(Transform playerTransform, PlayerBodyData playerData, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, Camera camera)
        {
            _playerTransform = playerTransform;
            _playerData = playerData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _camera = camera;
        }

        public void Initialize()
        {
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisChange;
            _movement = new Movement(_playerData, _playerTransform.GetComponent<Rigidbody>());
        }


        private void VerticalOnAxisChange(float obj)
        {
            _vertical = obj;
        }

        private void HorizontalOnAxisChange(float obj)
        {
            _horizontal = obj;
        }

        public void Execute(float deltaTime)
        {
            var cameraDirection = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1)).normalized;
            var direction = (_vertical * cameraDirection + _horizontal * _camera.transform.right).normalized;
            _movement.Move(direction);
        }

        public void CleanUp()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisChange;
        }
    }
}

