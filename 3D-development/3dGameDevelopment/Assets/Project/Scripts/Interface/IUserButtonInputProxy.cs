using System;

namespace Project
{
    public interface IUserButtonInputProxy
    {
        event Action<bool> MouseButtonOnChangeUp;
        event Action<bool> MouseButtonOnChangeDown;
        void GetButtonDown();
        void GetButtonUp();
    } 
}