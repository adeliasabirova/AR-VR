﻿namespace Asteroids
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}
