using UnityEngine;

namespace Asteroids
{
    public sealed class Comet : Enemy
    {
        private IMoveEnemy _moveComet;

        private void Start()
        {
            _moveComet = new MoveComet(transform, Random.Range(5.0f, 10.0f));
        }

        private void Update()
        {
            _moveComet.Move(transform.position, Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}

