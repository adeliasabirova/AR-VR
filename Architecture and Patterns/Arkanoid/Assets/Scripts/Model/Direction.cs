using UnityEngine;

namespace Arkanoid
{
    internal sealed class Direction : IDirection
    {
        public Vector2 HitFactor(Vector2 position, Vector2 targetPosition, float targetWidth)
        {
            var vector = new Vector2((position.x - targetPosition.x) / targetWidth, 1).normalized;
            return vector;
        }
    }
}