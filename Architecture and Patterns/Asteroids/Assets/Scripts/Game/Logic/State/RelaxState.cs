using UnityEngine;

namespace Asteroids
{
    public sealed class RelaxState : State
    {
        public RelaxState(FireStateController unit) : base(unit)
        {
        }

        public override void OnStateEnter()
        {
            _unit.Unit.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }

        public override void Handle()
        {
            if (_unit.FireDown)
                _unit.SetState(new FireState(_unit));
        }
    }
}