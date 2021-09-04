using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _unit;
        private Vector3 _move;
        public MoveTransform(Transform unit, float speed)
        {
            Speed = speed;
            _unit = unit;
        }
        public float Speed  { get; protected set;}
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _unit.localPosition += _move;
        }
    }
}