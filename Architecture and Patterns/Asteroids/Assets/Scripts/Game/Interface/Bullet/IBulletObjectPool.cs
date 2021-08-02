using UnityEngine;

namespace Asteroids
{
    public interface IBulletObjectPool
    {
        IBullet CreateBullet(Vector3 position, Quaternion rotation, Vector3 direction);
    }
}