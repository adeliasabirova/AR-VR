using UnityEngine;

namespace Asteroids
{
    internal sealed class EnemyShip : Enemy
    {
        private IMoveEnemy _moveShipEnemy;
        private Transform _targetTransform;

        private void Start()
        {
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _moveShipEnemy = new MoveEnemyShip(transform, Random.Range(2.0f, 6.0f), 1f);
        }

        private void Update()
        {
            _moveShipEnemy.Move(_targetTransform.position, Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health.ChangeCurrentHealth(10);
        }


        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}

