using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Rigidbody2D _bulletRigidBody;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Rigidbody2D _rigidBody;
        private Ship _ship;
        private IInputController _shiftKey;
        private IInputController _buttonKey;
        private IPlayer _playerHP;
        private IBullet _bullet; 

        private void Awake()
        {
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(_rigidBody, _speed, _acceleration);
            var rotateTransform = new RotateShip(transform);
            _ship = new Ship(moveTransform, rotateTransform);
            _shiftKey = new KeyShiftPressed();
            _buttonKey = new KeyButtonPressed("Fire1");
            _playerHP = new PlayerHP(gameObject);
        }
        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (_shiftKey.DownKeyReceived())
                _ship.AddAcceleration();

            if (_shiftKey.UpKeyReceived())
                _ship.RemoveAcceleration();

            if (_buttonKey.DownKeyReceived())
            {
                _bullet = new Bullet(_bulletRigidBody, _barrel.position, _barrel.rotation, _barrel.up);
                _bullet.Create();
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            _playerHP.HPChanged(10);
        }
    }

}

