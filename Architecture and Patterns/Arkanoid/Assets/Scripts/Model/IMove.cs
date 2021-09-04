using UnityEngine;

namespace Arkanoid
{
    public interface IMove
    {
        Vector2 Direction { get; set; }
        float Speed { get; }
        Vector2 Movement(float horizontal);
    }
}