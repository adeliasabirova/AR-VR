using UnityEngine;

namespace Arkanoid
{
    internal sealed class BallViewModel : IViewModelDirection
    {
        public BallViewModel(float speed, Vector2 direction, Rigidbody2D unit)
        {
            MoveModel = new Move(speed, direction);
            Unit = unit;
            DirectionModel = new Direction();
        }

        public IMove MoveModel { get; private set; }

        public Rigidbody2D Unit { get; private set; }

        public IDirection DirectionModel { get; private set; }

        public void Movement(float horizontal)
        {
            Unit.velocity = MoveModel.Movement(horizontal);
        }

        public void DirectionChanged(Vector2 position, Vector2 targetPosition, float targetWidth)
        {
            var newDirection = DirectionModel.HitFactor(position, targetPosition, targetWidth);
            MoveModel.Direction = newDirection;
        }
    }
}