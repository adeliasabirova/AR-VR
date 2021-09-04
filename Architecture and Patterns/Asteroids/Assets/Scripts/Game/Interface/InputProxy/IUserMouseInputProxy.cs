using System;
using UnityEngine;

namespace Asteroids
{
    public interface IUserMouseInputProxy
    {
        event Action<bool> MouseButtonOnChangeUp;
        event Action<bool> MouseButtonOnChangeDown;
        void GetButtonDown();
        void GetButtonUp();
        Vector3 GetMousePosition();
    }
}