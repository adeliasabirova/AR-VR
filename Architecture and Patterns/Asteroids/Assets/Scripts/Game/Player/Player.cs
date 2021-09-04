using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public sealed class Player : MonoBehaviour, IPlayer, IScore
    {
        private Health _health;
        private int _score;
        private int _defense;
        public int Score => _score;
        public int Defense
        {
            get => _defense;
            set => _defense = value;
        }
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

        public void ScoreCalculate(int score)
        {
            _score += score;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.TryGetComponent<IEnemy>(out var component))
            {
                var damage = component[Random.Range(0, component.NumberOfAbilities)].Damage;
                _health.ChangeCurrentHealth(damage/ _defense);
            }
            
            if (_health.CurrentHP <= 0)
                Destroy(transform);
        }

        
    }

}

