using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyObjectPool : IEnemyObjectPool
    {
        private readonly GameObject _prefab;
        private int _currentID;
        private int _maxID;

        public EnemyObjectPool(GameObject prefab, int maxID, Camera camera)
        {
            _prefab = prefab;
            _currentID = 0;
            _maxID = maxID;
        }

        public IEnemy CreateEnemy(Vector3 position, float speed)
        {
            if (_currentID == _maxID) _currentID = 0;
            var enemyGameObject = ServiceLocator.Resolve<IViewService>().Create(_currentID, _prefab, true);
            var enemy = enemyGameObject.GetComponent<Asteroid>();
            enemy.Initiate(enemyGameObject, _currentID);
            enemy.transform.position = position;
            enemy.Speed = speed;
            _currentID += 1;
            return enemy;
        }
    }
}