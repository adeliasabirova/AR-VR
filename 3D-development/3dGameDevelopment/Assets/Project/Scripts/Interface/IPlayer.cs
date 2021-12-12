using System;

namespace Project
{
    public interface IPlayer
    {
        event Action<float> OnAnimatorMoveChange;
        event Action<int> OnAnimatorIKChange;
    }
}