using UnityEngine;

namespace Asteroids.Additional
{
    internal sealed class MagicalAttack : IAttack
    {
        private Transform _transform;
        private float _speed;

        public MagicalAttack(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Attack(float deltaTime)
        {
            _transform.Rotate(Vector3.forward * _speed * deltaTime);
        }
    }
}