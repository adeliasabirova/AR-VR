using UnityEngine;

namespace Asteroids.Additional
{

    internal sealed class Infantry : IMove
    {
        private Transform _transform;
        private float _speed;

        public Infantry(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(float deltaTime)
        {
            _transform.position += Vector3.down * _speed * deltaTime;
        }
    }
}