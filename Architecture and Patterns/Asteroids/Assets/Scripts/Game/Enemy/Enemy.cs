using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        private Health _health;
        private bool _isDestroyed = false;
        public Health Health
        {
            get
            {
                return _health;
            }
            protected set => _health = value;
        }

        public event Action<int> OnTriggerEnterChange;

        public virtual void Move(Vector3 position, float deltaTime)
        {
        }

        public virtual void OnTriggerEvent()
        {
        }

        public float Speed { get; set; }

        public virtual void OnCollisionEnter2D(Collision2D collision)
        {
            _isDestroyed = true;
            OnTriggerEnterChange?.Invoke(gameObject.GetInstanceID());
        }

        public virtual void OnBecameInvisible()
        {
            if(!_isDestroyed)
                OnTriggerEnterChange?.Invoke(gameObject.GetInstanceID());
        }


        public int GetInstanceIDEnemy()
        {
            return gameObject.GetInstanceID();
        }
    }
}
