using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    internal sealed class AmmunitionPool
    {
        private readonly Dictionary<string, HashSet<Ammunition>> _ammunitionPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public AmmunitionPool(int capacityPool)
        {
            _ammunitionPool = new Dictionary<string, HashSet<Ammunition>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new
                GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }

        public Ammunition GetAmmunition(string type)
        {
            Ammunition result;
            switch (type)
            {
                case "Bullet":
                    result = GetBullet(GetListAmmunitions(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            return result;
        }

        private HashSet<Ammunition> GetListAmmunitions(string type)
        {
            return _ammunitionPool.ContainsKey(type) ? _ammunitionPool[type] :
            _ammunitionPool[type] = new HashSet<Ammunition>();
        }

        private Ammunition GetBullet(HashSet<Ammunition> ammunitions)
        {
            var ammunition = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (ammunition == null)
            {
                var laser = Resources.Load<BulletAmmunition>("Ammunition/Bullet");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    ammunitions.Add(instantiate);
                }
                GetBullet(ammunitions);
            }
            ammunition = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            return ammunition;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}