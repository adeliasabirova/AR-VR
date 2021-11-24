using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(MouseLook))]
public class PlayerCharacter : Character, IDamage
{
    [Range(0, 100)] [SerializeField] private int _health = 100;
    private int _currentHealth;

    [Range(0.5f, 10.0f)] [SerializeField] private float _movingSpeed = 8.0f;
    [SerializeField] private float _acceleration = 3.0f;
    private const float _gravity = -9.8f;
    private CharacterController _characterController;
    private MouseLook _mouseLook;

    private Vector3 _currentVelocity;

    protected override FireAction _fireAction { get; set; }

    protected override void Initiate()
    {
        base.Initiate();
        _fireAction = GetComponent<RayShooter>();
        _fireAction ??= gameObject.AddComponent<RayShooter>();
        _fireAction.Reloading();
        _characterController = GetComponent<CharacterController>();
        _characterController ??= gameObject.AddComponent<CharacterController>();
        _mouseLook = GetComponent<MouseLook>();
        _mouseLook ??= gameObject.AddComponent<MouseLook>();

        _currentHealth = _health;
    }

    public override void Movement()
    {
        if (_mouseLook != null && _mouseLook.PlayerCamera != null)
        {
            _mouseLook.PlayerCamera.enabled = hasAuthority;
        }

        if (hasAuthority)
        {
            var moveX = Input.GetAxis("Horizontal") * _movingSpeed;
            var moveZ = Input.GetAxis("Vertical") * _movingSpeed;
            var movement = new Vector3(moveX, 0, moveZ);
            movement = Vector3.ClampMagnitude(movement, _movingSpeed);
            movement *= Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement *= _acceleration;
            }

            movement.y = _gravity;
            movement = transform.TransformDirection(movement);

            _characterController.Move(movement);
            _mouseLook.Rotation();

            CmdUpdatePosition(transform.position);
            CmdUpdateRotation(transform.rotation);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, _serverPosition, ref _currentVelocity, _movingSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _serverRotation, 0.5f);
        }

    }

    private void Start()
    {
        Initiate();
    }
    private void OnGUI()
    {
        if (Camera.main == null)
        {
            return;
        }

        var info = $"Health: {_currentHealth}\nClip: {RayShooter.BulletCount}";
        var size = 12;
        var bulletCountSize = 50;
        var posX = Camera.main.pixelWidth / 2 - size / 4;
        var posY = Camera.main.pixelHeight / 2 - size / 2;
        var posXBul = Camera.main.pixelWidth - bulletCountSize * 2;
        var posYBul = Camera.main.pixelHeight - bulletCountSize;
        GUI.Label(new Rect(posX, posY, size, size), "+");
        GUI.Label(new Rect(posXBul, posYBul, bulletCountSize * 2, bulletCountSize * 2), info);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            if(!isServer)
                NetworkManager.singleton.StopClient();
        }
    }
}

