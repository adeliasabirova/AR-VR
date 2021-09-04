using UnityEngine;

namespace Asteroids
{
    public sealed class FireState : State
    {
        public FireState(FireStateController unit) : base(unit)
        {
        }

        public override void OnStateEnter()
        {
            _unit.Unit.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }

        public override void Handle()
        {
            if (_unit.FireUp)
                _unit.SetState(new RelaxState(_unit));
        }
    }
}