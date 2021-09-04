using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        private Transform _rotPool;
        private Health _health;
        public Health Health
        {
            get
            {
                if (_health.CurrentHP <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_ENEMIES);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }
        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);
            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }
        public static Comet CreateComet(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Comet>("Enemy/Comet"));
            enemy.Health = hp;
            return enemy;
        }

    }
}
