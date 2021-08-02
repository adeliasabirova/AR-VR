using UnityEngine;

namespace Asteroids
{
    public interface IMoveEnemy
    {
        float Speed { get; }
        void Move(Vector3 position, float deltaTime);
    }
}
