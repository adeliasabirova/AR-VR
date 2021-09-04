using UnityEngine;

namespace Asteroids.Decorator
{
    internal interface IAim
    {
        Transform Position { get; }
        GameObject AimInstance { get; }
        float DistanceFromGun { get; }
    }
}