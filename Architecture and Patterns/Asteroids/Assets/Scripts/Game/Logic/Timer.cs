using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Timer : ITimer
    {
        private float _currentTime = 0;
        private float _readyTime;

        public Timer(float readyTime)
        {
            _readyTime = readyTime;
        }

        public bool Tick(float deltatime)
        {
            _currentTime += deltatime;
            if (_currentTime >= _readyTime)
            {
                _currentTime = 0;
                return true;
            }
            else
                return false;
        }
    }
}
