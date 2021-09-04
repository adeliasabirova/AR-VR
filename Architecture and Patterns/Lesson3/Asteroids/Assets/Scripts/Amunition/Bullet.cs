using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Bullet : IBullet
    {
        private readonly Vector3 _position;
        private readonly Quaternion _rotation;
        private readonly Vector3 _direction;
        private float _force = 10;
        private AmmunitionPool _ammunitionPool;

        public Bullet(AmmunitionPool ammunitionPool, Vector3 position, Quaternion rotation, Vector3 direction)
        {
            _position = position;
            _rotation = rotation;
            _direction = direction;
            _ammunitionPool = ammunitionPool;
        }

        public void Create()
        {
            var bullet = _ammunitionPool.GetAmmunition("Bullet");
            bullet.transform.position = _position;
            bullet.transform.rotation = _rotation;
            bullet.gameObject.SetActive(true);
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_direction * _force, ForceMode2D.Impulse);
        }

    }
}