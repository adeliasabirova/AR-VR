using UnityEngine;

namespace Asteroids
{
    internal sealed class EnemyShip : Enemy
    {
        private float _stoppingDistance = 1f;
        private Vector3 _moveVector;

        public override void Move(Vector3 position, float deltaTime)
        {
            base.Move(position, deltaTime);
            if ((transform.position - position).sqrMagnitude >= _stoppingDistance)
            {
                var direction = (position - transform.localPosition).normalized;
                var speed = Speed * deltaTime;
                _moveVector = direction * speed;
            }
            else
            {
                _moveVector = Vector3.zero;
            }
            transform.localPosition += _moveVector;
        }

        public override void OnTriggerEvent()
        {
            base.OnTriggerEvent();
            Destroy(gameObject);
        }


        protected override int Weight()
        {
            return 5 * base.Weight();
        }
    }
}

