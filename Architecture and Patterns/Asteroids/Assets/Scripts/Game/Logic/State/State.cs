using System;

namespace Asteroids
{
    public abstract class State
    {
        protected FireStateController _unit;

        protected State(FireStateController unit)
        {
            _unit = unit;
        }
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
        public abstract void Handle();
    }
}