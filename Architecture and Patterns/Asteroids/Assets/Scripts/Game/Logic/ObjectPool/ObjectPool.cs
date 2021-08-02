using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class ObjectPool
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private bool _isPrefab;

        public ObjectPool(GameObject prefab, bool isPrefab)
        {
            _prefab = prefab;
            _isPrefab = isPrefab;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.SetActive(false);
        }

        public GameObject Pop()
        {
            GameObject go;
            if(_stack.Count == 0)
            {
                if (_isPrefab)
                    go = Object.Instantiate(_prefab);
                else
                    go = _prefab;
            }
            else
            {
                go = _stack.Pop();
            }
            go.SetActive(true);

            return go;
        }
    }
}