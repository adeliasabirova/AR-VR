using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal abstract class Ammunition : MonoBehaviour
    {
        private Transform _rotPool;

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }

        public void ActiveAmmunition(Vector3 position, Quaternion rotation)
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
    }
}
