using System;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Asteroid : Enemy
    {
        private IMoveEnemy _moveAsteroid;
        //private ViewService _viewService;
        private GameObject _prefab;
        private int _idEnemy;

        public void Initiate( GameObject gameObject, int id)
        {
            //_viewService = viewService;
            _prefab = gameObject;
            _idEnemy = id;
        }

        public override void Move(Vector3 position, float deltaTime)
        {
            base.Move(position, deltaTime);
            transform.position += Vector3.down * Speed * deltaTime;
        }

        public override void OnTriggerEvent()
        {
            base.OnTriggerEvent();
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            ServiceLocator.Resolve<IViewService>().Destroy(_idEnemy, _prefab);
        }
    }
}
