using UnityEngine;

namespace Arkanoid
{
    internal sealed class BallFabric : IFabric
    {
        public IView Create(Vector3 position, Quaternion rotation)
        {
            var ball = Object.Instantiate(Resources.Load<BallView>("Player/ball"), position, rotation);
            return ball;
        }
    }
}