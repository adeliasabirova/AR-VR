using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class FireStateController : IInitialize, IExecute, ICleanup
    {
        private readonly Transform _unit;
        private IUserMouseInputProxy _mouseInputProxy;
        private bool _fireDown;
        private bool _fireUp;
        private State _currentState;

        public Transform Unit => _unit;
        public bool FireDown => _fireDown;
        public bool FireUp => _fireUp;

        public void SetState(State state)
        {
            if (_currentState != null)
                _currentState.OnStateExit();

            _currentState = state;

            if (_currentState != null)
                _currentState.OnStateEnter();
        }

        public FireStateController(Transform unit, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserMouseInputProxy inputFire, IUserKeyInputProxy inputShift) input)
        {
            _unit = unit;
            _mouseInputProxy = input.inputFire;
        }

        public void Cleanup()
        {
            _mouseInputProxy.MouseButtonOnChangeDown -= MouseButtonDownOnChange;
            _mouseInputProxy.MouseButtonOnChangeUp -= MouseButtonUPOnChange;
        }

        public void Execute(float deltaTime)
        {
            _currentState.Handle();
        }

        public void Initialize()
        {
            _mouseInputProxy.MouseButtonOnChangeDown += MouseButtonDownOnChange;
            _mouseInputProxy.MouseButtonOnChangeUp += MouseButtonUPOnChange;
            _currentState = new RelaxState(this);
        }

        private void MouseButtonUPOnChange(bool obj)
        {
            _fireUp = obj;
        }

        private void MouseButtonDownOnChange(bool obj)
        {
            _fireDown = obj;
        }
    }
}