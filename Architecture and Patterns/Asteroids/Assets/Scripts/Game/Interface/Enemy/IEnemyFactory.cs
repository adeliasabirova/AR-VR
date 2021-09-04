using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyType type, Vector3 position, float speed);
    }
}