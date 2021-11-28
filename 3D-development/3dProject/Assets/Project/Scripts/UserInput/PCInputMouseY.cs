﻿using System;
using UnityEngine;

namespace Game
{
    public sealed class PCInputMouseY : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate (float f) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(InputManager.MOUSE_Y));
        }
    }
}