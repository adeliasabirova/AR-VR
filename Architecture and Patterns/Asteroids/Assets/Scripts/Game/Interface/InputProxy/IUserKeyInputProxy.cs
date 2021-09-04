using System;

namespace Asteroids
{
    public interface IUserKeyInputProxy
    {
        event Action<bool> KeyOnChangeUp;
        event Action<bool> KeyOnChangeDown;
        void GetKeyDown();
        void GetKeyUp();
    }
}