using System;

namespace Asteroids
{
    public interface IBullet
    {
        event Action<int> OnTriggerEnterChange;
    }
}