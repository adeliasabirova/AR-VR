using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Bullet : IBullet
    {
        private readonly Rigidbody2D _prefab;
        private readonly Vector3 _position;
        private readonly Quaternion _rotation;
        private readonly Vector3 _direction;
        private float _force = 10;

        public Bullet(Rigidbody2D prefab, Vector3 position, Quaternion rotation, Vector3 direction)
        {
            _prefab = prefab;
            _position = position;
            _rotation = rotation;
            _direction = direction;
        }

        public void Create()
        {
            var bullet = GameObject.Instantiate(_prefab, _position, _rotation);
            bullet.AddForce(_direction * _force, ForceMode2D.Impulse);
        }
    }
}