using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        private Health _health;
        private bool _isDestroyed = false;
        private IScore _player;
        private List<IAbility> _ability;
        
        public List<IAbility> Ability
        {
            get => _ability;
            set => _ability = value;
        }
        
        public IScore Player
        {
            get => _player;
            set => _player = value;
        }
        public Health Health
        {
            get
            {
                return _health;
            }
            protected set => _health = value;
        }

        public event Action<int> OnTriggerEnterChange;
        public event Action<int> OnBecomeInvisibleChange;

        public virtual void Move(Vector3 position, float deltaTime)
        {
        }

        public virtual void OnTriggerEvent()
        {
        }

        protected virtual int Weight()
        {
            return 100;
        }
        public float Speed { get; set; }

        public int MaxDamage => _ability.Select(a => a.Damage).Max();

        public int NumberOfAbilities => _ability.Count;

        public IAbility this[int index] => _ability[index];

        public virtual void OnCollisionEnter2D(Collision2D collision)
        {
            _isDestroyed = true;
            OnTriggerEnterChange?.Invoke(gameObject.GetInstanceID());
            Debug.Log("Enemy is destroied.");
            if(!collision.gameObject.TryGetComponent<IScore>(out var component))
            {
                _player.ScoreCalculate(Weight());
            }
        }

        public virtual void OnBecameInvisible()
        {
            //if(!_isDestroyed)
            OnBecomeInvisibleChange?.Invoke(gameObject.GetInstanceID());
        }


        public int GetInstanceIDEnemy()
        {
            return gameObject.GetInstanceID();
        }

        public IEnumerable<IAbility> GetAbility()
        {
            while (true)
            {
                yield return _ability[Random.Range(0, _ability.Count)];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _ability.Count; i++)
            {
                yield return _ability[i];
            }
        }

        public IEnumerable<IAbility> GetAbility(DamageType index)
        {
            foreach (IAbility ability in _ability)
            {
                if (ability.DamageType == index)
                {
                    yield return ability;
                }
            }
        }

        public void Activate(IDealingCreate value, Vector3 position)
        {
            value.Visit(this, new InfoCreation(position));
        }

    }
}
