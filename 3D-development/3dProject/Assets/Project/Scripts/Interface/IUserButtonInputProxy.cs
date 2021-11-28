using System;

namespace Game
{
    public interface IUserButtonInputProxy
    {
        event Action<bool> MouseButtonOnChangeUp;
        event Action<bool> MouseButtonOnChangeDown;
        void GetButtonDown();
        void GetButtonUp();
    }
}