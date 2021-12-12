using System;

namespace Game
{
    public interface IPlayer
    {
        event Action<float> OnAnimatorMoveChange;
        event Action<int> OnAnimatorIKChange;
    }
}