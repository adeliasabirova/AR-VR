using System.Collections;
using UnityEngine;

public class RayShooter : FireAction
{
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _bulletTorque;
    public static string BulletCount;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reloading();
        }

        if (Input.anyKey && !Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    protected override void Shooting()
    {
        base.Shooting();
        if (bullets.Count > 0)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        if (reloading)
        {
            yield break;
        }

        if (hasAuthority)
        {
            var shoot = bullets.Dequeue();
            BulletCount = bullets.Count.ToString();
            ammunition.Enqueue(shoot);
            shoot.SetActive(true);
            shoot.transform.position = _bulletStartPosition.position;
            shoot.transform.rotation = transform.rotation;
            var shootRigidBody = shoot.GetComponent<Rigidbody>();
            shootRigidBody.AddForce(transform.forward * _bulletForce);
            shootRigidBody.AddTorque(Random.insideUnitSphere * _bulletTorque);

            yield return new WaitForSeconds(2.0f);
            shoot.SetActive(false);
        }
    }
}
