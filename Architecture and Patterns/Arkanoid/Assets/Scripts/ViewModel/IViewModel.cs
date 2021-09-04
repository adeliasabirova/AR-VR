using UnityEngine;

namespace Arkanoid
{
    public interface IViewModel
    {
        IMove MoveModel { get; }
        Rigidbody2D Unit { get; }
        void Movement(float horizontal);

    }
}