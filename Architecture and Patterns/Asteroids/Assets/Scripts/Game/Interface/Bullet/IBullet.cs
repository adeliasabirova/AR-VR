using System;
using UnityEngine;

namespace Asteroids
{
    public interface IBullet
    {
        event Action<int> OnTriggerEnterChange;
        void Activate(IDealingCreate value, Vector3 position);
    }
}