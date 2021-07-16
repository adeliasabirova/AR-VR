using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class PCInputFire : IUserMouseInputProxy
    {
        public event Action<bool> MouseButtonOnChangeUp = delegate(bool b) { };
        public event Action<bool> MouseButtonOnChangeDown = delegate (bool b) { };

        public void GetButtonDown()
        {
            MouseButtonOnChangeDown.Invoke(Input.GetButtonDown(InputManager.FIRE));
        }

        public void GetButtonUp()
        {
            MouseButtonOnChangeUp.Invoke(Input.GetButtonUp(InputManager.FIRE));
        }

        public Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }
    }
}