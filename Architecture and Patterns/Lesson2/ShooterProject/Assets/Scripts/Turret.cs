using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _minDistance = 3;
    [SerializeField] private float _rotationSpeed;
    public GameObject _bulletPref;
    float _bulletTime = 0;
    float _interval = 150;

    private float _force = 200f;
    [SerializeField]private BulletCreation bulletCreation;

    LookAtPlayer lookAt;

    private void Start()
    {
        lookAt = new LookAtPlayer();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, _playerPosition.position) < _minDistance)
        {
            transform.rotation = lookAt.LookAt(transform.forward, _playerPosition.position - transform.position, _rotationSpeed * Time.deltaTime);
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        if (_bulletTime == _interval)
        {
            var position = new Vector3(transform.GetChild(0).position.x + transform.GetChild(0).localScale.x, transform.GetChild(0).position.y, transform.GetChild(0).position.z);
            bulletCreation.CreateBullet(position, _bulletPref, transform.rotation, transform.forward * _force, transform.forward * 10);
            _bulletTime = 0;
        }
        else
            _bulletTime += 1;
    }

}
