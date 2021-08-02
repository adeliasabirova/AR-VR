using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class PCInputShift : IUserKeyInputProxy
    {
        public event Action<bool> KeyOnChangeUp = delegate(bool b) { };
        public event Action<bool> KeyOnChangeDown = delegate (bool b) { };

        public void GetKeyDown()
        {
            KeyOnChangeDown.Invoke(Input.GetKeyDown(InputManager.LEFTSHIFT));
        }

        public void GetKeyUp()
        {
            KeyOnChangeUp.Invoke(Input.GetKeyUp(InputManager.LEFTSHIFT));
        }
    }
}