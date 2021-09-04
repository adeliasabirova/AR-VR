using UnityEngine;

namespace Asteroids.Additional
{
    internal sealed class Mag : IMove
    {
        private Transform _transform;
        private float _speed;

        public Mag(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(float deltaTime)
        {
            _transform.position += Vector3.right * _speed * deltaTime;
        }
    }
}