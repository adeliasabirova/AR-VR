using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Aim : IAim
    {
        public Aim(Transform position, GameObject aimInstance)
        {
            Position = position;
        }
        public Transform Position { get; }
    }
}