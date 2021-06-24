using UnityEngine;

namespace Asteroids
{
    internal sealed class MoveEnemyShip : MoveEnemy
    {
        private float _stoppingDistance;
        public MoveEnemyShip(Transform transform, float speed, float stoppingDistance) : base(transform, speed)
        {
            _stoppingDistance = stoppingDistance;
        }

        public override void Move(Vector3 position, float deltaTime)
        {
            base.Move(position, deltaTime);
            if ((Transform.position - position).sqrMagnitude >= _stoppingDistance)
            {
                var direction = (position - Transform.localPosition).normalized;
                var speed = Speed * deltaTime;
                MoveVector = direction * speed;
            }
            else
            {
                MoveVector = Vector3.zero;
            }
            Transform.localPosition += MoveVector;
        }
    }
}
