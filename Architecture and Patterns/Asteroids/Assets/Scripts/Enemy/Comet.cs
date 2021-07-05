using System;
using UnityEngine;

namespace Asteroids
{
    [Serializable]
    public sealed class Comet : Enemy
    {
        private IMoveEnemy _moveComet;

        public static Comet CreateComet(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Comet>("Enemy/Comet"));
            enemy.Health = hp;
            return enemy;
        }

        private void Start()
        {
            _moveComet = new MoveComet(transform, UnityEngine.Random.Range(5.0f, 10.0f));
        }

        private void Update()
        {
            _moveComet.Move(transform.position, Time.deltaTime);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}

