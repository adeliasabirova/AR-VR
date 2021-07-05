using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IBullet
    {
        void Create(Vector3 position, Quaternion rotation, Vector3 direction);
    }
}