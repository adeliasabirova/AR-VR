using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Rigidbody2D _rigidBody;
        private Vector3 _move;

        public MoveTransform(Rigidbody2D rigidBody, float speed)
        {
            Speed = speed;
            _rigidBody = rigidBody;
        }
        public float Speed  { get; protected set;}
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            if (_move.Equals(Vector3.zero))
            {
                _rigidBody.velocity = Vector2.zero;
            }
            else
            {
                _rigidBody.velocity = _move * 500;
            }
        }
    }
}