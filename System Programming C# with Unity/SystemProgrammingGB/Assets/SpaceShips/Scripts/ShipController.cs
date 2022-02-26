using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SpaceShips
{
    public class ShipController : NetworkMovableObject
    {        
        protected override float _speed => _shipSpeed;

        [SerializeField] private Transform _cameraAttach;
        [SerializeField] private Transform _shipObject;

        private CameraOrbit _cameraOrbit;
        private PlayerLabel _playerLabel;
        private float _shipSpeed;
        private Rigidbody _rb;
        private IShip _ship;

        private string _input;

        [ClientRpc]
        public void RpcSetInput(string input)
        {
            _input = input;
        }

        [SyncVar] private string _playerName;

        [Command]
        private void CmdSetPlayerName(string name)
        {
            _playerName = name;
        }

        private void OnGUI()
        {
            if (_cameraOrbit == null)
            {
                return;
            }
            _cameraOrbit.ShowPlayerLabels(_playerLabel);
        }

        public override void OnStartAuthority()
        {
            CmdSetPlayerName(_input);
            _rb = GetComponent<Rigidbody>();
            if (_rb == null)
            {
                return;
            }
            gameObject.name = _playerName;
            _cameraOrbit = FindObjectOfType<CameraOrbit>();
            _cameraOrbit.Initiate(_cameraAttach == null ? transform : _cameraAttach);
            _playerLabel = GetComponentInChildren<PlayerLabel>();
            base.OnStartAuthority();
        }

        protected override void HasAuthorityMovement()
        {
            var spaceShipSettings = SettingsContainer.Instance?.SpaceShipSettings;
            if (spaceShipSettings == null)
            {
                return;
            }

            var isFaster = Input.GetKey(KeyCode.LeftShift);
            var speed = spaceShipSettings.ShipSpeed;
            var faster = isFaster ? spaceShipSettings.Faster : 1.0f;

            _shipSpeed = Mathf.Lerp(_shipSpeed, speed * faster,
                SettingsContainer.Instance.SpaceShipSettings.Acceleration);

            var currentFov = isFaster
                ? SettingsContainer.Instance.SpaceShipSettings.FasterFov
                : SettingsContainer.Instance.SpaceShipSettings.NormalFov;
            _cameraOrbit.SetFov(currentFov, SettingsContainer.Instance.SpaceShipSettings.ChangeFovSpeed);

            var velocity = _cameraOrbit.transform.TransformDirection(Vector3.forward) * _shipSpeed;
            _rb.velocity = velocity * Time.deltaTime;

            if (!Input.GetKey(KeyCode.C))
            {
                var targetRotation = Quaternion.LookRotation(
                    Quaternion.AngleAxis(_cameraOrbit.LookAngle, -transform.right) *
                    velocity);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }
        }

        protected override void FromServerUpdate() { }
        protected override void SendToServer() { }

        [ClientCallback]
        private void Start()
        {
            _ship = _shipObject.GetComponent<IShip>();
            _ship.OnCollisionEnterChange += CollisionEnterChange;
        }

        [ClientCallback]
        private void Update()
        {
            Movement();
        }

        private void CollisionEnterChange()
        {
            Vector3 newPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            CmdRespawn(newPosition);
        }

        [Command]
        private void CmdRespawn(Vector3 position)
        {
            _shipObject.gameObject.SetActive(false);
            transform.position = position;
            _shipObject.gameObject.SetActive(true);
        }

        [ClientCallback]
        private void LateUpdate()
        {
            _cameraOrbit?.CameraMovement();
        }

        [ClientCallback]
        private void OnDestroy()
        {
            _ship.OnCollisionEnterChange -= CollisionEnterChange;
        }

    }
}