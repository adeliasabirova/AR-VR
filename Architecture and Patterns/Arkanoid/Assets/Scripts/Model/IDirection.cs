using UnityEngine;

namespace Arkanoid
{
    public interface IDirection
    {
        Vector2 HitFactor(Vector2 position, Vector2 targetPosition, float targetWidth);
    }
}