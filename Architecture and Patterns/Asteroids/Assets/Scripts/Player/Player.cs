using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private Sprite _spriteBullet;
        private Camera _camera;
        private Rigidbody2D _rigidBody;
        private Ship _ship;
        private InputController _inputController;
        private IPlayer _playerHP;
        private IBullet _bullet;
        private int _capacityBullet = 5;
        private ViewService _viewService;

        private void Awake()
        {
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            _viewService = new ViewService(capacity: _capacityBullet);
        }

        private void Start()
        {
            _camera = Camera.main;

            var moveTransform = new AccelerationMove(_rigidBody, _speed, _acceleration);
            var rotateTransform = new RotateShip(transform);
            _ship = new Ship(moveTransform, rotateTransform);

            var shiftKey = new KeyShiftPressed();
            var buttonKey = new KeyButtonPressed("Fire1");
            _inputController = new InputController(shiftKey, buttonKey);

            _playerHP = new PlayerHP(gameObject);
            _bullet = new Bullet(_viewService, _spriteBullet);
        }
        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);


            if (_inputController.IsKeyShiftDown)
                _ship.AddAcceleration();

            if (_inputController.IsKeyShiftUp)
                _ship.RemoveAcceleration();

            if (_inputController.IsKeyButtonDown)
            {
                _bullet.Create(_barrel.position, _barrel.rotation, _barrel.up);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            _playerHP.HPChanged(10);
        }
    }

}

