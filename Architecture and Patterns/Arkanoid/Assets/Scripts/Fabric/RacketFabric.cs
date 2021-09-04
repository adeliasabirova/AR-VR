using UnityEngine;

namespace Arkanoid
{
    internal sealed class RacketFabric : IFabric
    {
        public IView Create(Vector3 position, Quaternion rotation)
        {
            var racket = Object.Instantiate(Resources.Load<RacketView>("Player/racket"), position, rotation);
            return racket;
        }
    }
}