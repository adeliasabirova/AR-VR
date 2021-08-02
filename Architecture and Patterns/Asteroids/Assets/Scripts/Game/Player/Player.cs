using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class Player : MonoBehaviour, IPlayer
    {
        private Health _health;
        public Health Health
        {
            get => _health;
            set => _health = value;
        }

        public event Action<int> OnCollisionEnterChange;
        public Transform GetTransform()
        {
            return transform;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _health.ChangeCurrentHealth(10);
            if (_health.CurrentHP <= 0)
                Destroy(transform);
        }

        
    }

}

