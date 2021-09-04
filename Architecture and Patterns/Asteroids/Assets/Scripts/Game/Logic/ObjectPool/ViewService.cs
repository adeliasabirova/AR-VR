using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IViewService
    {
        int Capacity { get;}
        GameObject Create(int id, GameObject prefab, bool isPrefab);
        GameObject GetGameObject(int id);
        void Destroy(int id, GameObject prefab);
    }
    public sealed class ViewService : IViewService
    {
        private int _capacity;
        private readonly Dictionary<int, ObjectPool> _viewCache;

        public int Capacity => _capacity;

        public ViewService(int capacity)
        {
            _capacity = capacity;
            _viewCache = new Dictionary<int, ObjectPool>(capacity: _capacity);
        }

        public GameObject Create(int id, GameObject prefab, bool isPrefab)
        {
            if(!_viewCache.TryGetValue(id, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab, isPrefab);
                _viewCache.Add(id, viewPool);
            }
            return viewPool.Pop();
        }

        public GameObject GetGameObject(int id)
        {
            _viewCache.TryGetValue(id, out ObjectPool viewPool);
            if (viewPool == null)
                return null;
            else
                return viewPool.Pop();
        }

        public void Destroy(int id, GameObject prefab)
        {
            _viewCache[id].Push(prefab);
        }
    }
}