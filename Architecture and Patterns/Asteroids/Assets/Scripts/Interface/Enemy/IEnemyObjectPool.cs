using UnityEngine;

namespace Asteroids
{
    public interface IEnemyObjectPool
    {
        IEnemy CreateEnemy(Vector3 position, float speed);
    }
}