using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Aim : IAim
    {
        public Aim(Transform position, GameObject aim, float distanceFromGun)
        {
            Position = position;
            AimInstance = aim;
            DistanceFromGun = distanceFromGun;
        }
        public Transform Position { get; }

        public GameObject AimInstance { get; }

        public float DistanceFromGun { get; }
    }
}