using UnityEngine;

namespace Asteroids
{
    internal sealed class Asteroid : Enemy
    {
        private IMoveEnemy _moveAsteroid;
        private void Start()
        {            
            _moveAsteroid = new MoveAsteroid(transform, Random.Range(5.0f, 8.0f));
        }

        private void Update()
        {
            _moveAsteroid.Move(transform.position, Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ReturnToPool();
        }
        private void OnBecameInvisible()
        {
            ReturnToPool();
        }

    }
}
