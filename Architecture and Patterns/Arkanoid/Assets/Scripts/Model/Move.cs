using UnityEngine;

namespace Arkanoid
{
    internal sealed class Move : IMove
    {
        public Move(float speed, Vector2 direction)
        {
            Speed = speed;
            Direction = direction;
        }

        public float Speed { get; private set; }

        public Vector2 Direction { get; set; }

        public Vector2 Movement(float horizontal)
        {
            return horizontal * Speed * Direction;
        }
    }
}