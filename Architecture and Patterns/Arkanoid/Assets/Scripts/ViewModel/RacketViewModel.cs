using UnityEngine;

namespace Arkanoid
{

    internal sealed class RacketViewModel : IViewModel
    {
        public RacketViewModel(float speed, Vector2 direction, Rigidbody2D unit)
        {
            MoveModel = new Move(speed, direction);
            Unit = unit;
        }

        public IMove MoveModel { get; private set; }

        public Rigidbody2D Unit { get; private set; }

        public void Movement(float horizontal)
        {
            Unit.velocity = MoveModel.Movement(horizontal);
        }
    }
}