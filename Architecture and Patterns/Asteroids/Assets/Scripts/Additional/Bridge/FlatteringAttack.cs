using UnityEngine;

namespace Asteroids.Additional
{
    internal sealed class FlatteringAttack : IAttack
    {
        private Transform _transform;
        private float _speed;

        public FlatteringAttack(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Attack(float deltaTime)
        {
            _transform.Rotate(Vector3.up*_speed*deltaTime);
        }
    }
}