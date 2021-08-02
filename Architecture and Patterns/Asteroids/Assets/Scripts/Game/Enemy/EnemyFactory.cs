using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyData _data;
        public EnemyFactory(EnemyData data)
        {
            _data = data;
        }
        public IEnemy CreateEnemy(EnemyType type, Vector3 position, float speed)
        {
            var enemy = _data.GetEnemy(type);
            var enemyGameObject = Object.Instantiate(enemy);
            enemyGameObject.transform.position = position;
            var enemySpeed = enemyGameObject.GetComponent<Enemy>();
            enemySpeed.Speed = speed;
            return enemyGameObject;
        }
    }
}
