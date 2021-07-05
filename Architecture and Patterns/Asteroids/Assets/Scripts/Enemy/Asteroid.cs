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

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
        private void ReturnToPool()
        {
            ServiceLocator.Resolve<IViewService>().Destroy(_idEnemy, _prefab);
        }

        private void Start()
        {            
            _moveAsteroid = new MoveAsteroid(transform, Random.Range(5.0f, 8.0f));
        }

        private void Update()
        {
            _moveAsteroid.Move(transform.position, Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ReturnToPool();
        }

        private void OnBecameInvisible()
        {
            ReturnToPool();
        }

    }
}
