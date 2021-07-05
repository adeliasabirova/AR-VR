using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal abstract class Ammunition : MonoBehaviour
    {
        private ViewService _viewService;
        private GameObject _prefab;
        private int _id;

        public void Initiate(ViewService viewService, GameObject gameObject, int id)
        {
            _viewService = viewService;
            _prefab = gameObject;
            _id = id;
        }

        protected void ReturnToPool()
        {
            _viewService.Destroy(_id, _prefab);
        }
    }
}
