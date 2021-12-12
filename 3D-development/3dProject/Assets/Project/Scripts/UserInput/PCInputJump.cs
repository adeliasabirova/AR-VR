using System;
using UnityEngine;

namespace Game
{
    public sealed class PCInputJump : IUserButtonInputProxy
    {
        public event Action<bool> MouseButtonOnChangeUp = delegate (bool b) { };
        public event Action<bool> MouseButtonOnChangeDown = delegate (bool b) { };

        public void GetButtonDown()
        {
            MouseButtonOnChangeDown.Invoke(Input.GetButtonDown(InputManager.Jump));
        }

        public void GetButtonUp()
        {
            MouseButtonOnChangeUp.Invoke(Input.GetButtonUp(InputManager.Jump));
        }

        public Vector3 GetMousePosition()
        {
            return Input.mousePosition;
        }
    }
}