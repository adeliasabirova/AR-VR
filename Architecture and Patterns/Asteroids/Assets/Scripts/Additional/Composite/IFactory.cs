using UnityEngine;

namespace Asteroids.Additional
{
    public interface IFactory
    {
        Enemy CreateFactory(EnemyInfo info, Vector3 position);
    }
}