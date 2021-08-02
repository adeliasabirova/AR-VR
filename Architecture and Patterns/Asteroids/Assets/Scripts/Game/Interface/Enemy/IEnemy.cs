using System;

namespace Asteroids
{
    public interface IEnemy : IMoveEnemy
    {
        event Action<int> OnTriggerEnterChange;
        void OnTriggerEvent();
        int GetInstanceIDEnemy();
    }
}