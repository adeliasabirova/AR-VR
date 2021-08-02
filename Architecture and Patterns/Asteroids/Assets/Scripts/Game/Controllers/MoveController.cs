using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class MoveController : IExecute, ICleanup, IInitialize
    {
        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private float _horizontal;
        private float _vertical;
        private bool _shiftDown;
        private bool _shiftUp;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private IUserKeyInputProxy _shiftInputProxy;
        private IUserMouseInputProxy _mouseInputProxy;
        private Ship _ship;
        private Camera _camera;


        public MoveController(Transform unit, IUnit unitData, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserMouseInputProxy inputFire, IUserKeyInputProxy inputShift) input, Camera camera)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _shiftInputProxy = input.inputShift;
            _mouseInputProxy = input.inputFire;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisChange;
            _shiftInputProxy.KeyOnChangeUp += KeyOnChangeUp;
            _shiftInputProxy.KeyOnChangeDown += KeyOnChangeDown;
            _camera = camera;
        }

        public void Initialize()
        {
            var moveTransform = new AccelerationMove(_unit, _unitData.Speed, _unitData.Acceleration);
            var rotateTransform = new RotateShip(_unit);
            _ship = new Ship(moveTransform, rotateTransform);
        }

        private void KeyOnChangeDown(bool obj)
        {
            _shiftDown = obj;
        }

        private void KeyOnChangeUp(bool obj)
        {
            _shiftUp = obj;
        }

        private void VerticalOnAxisChange(float obj)
        {
            _vertical = obj;
        }

        private void HorizontalOnAxisChange(float obj)
        {
            _horizontal = obj;
        }

        public void Execute(float deltaTime)
        {
            var direction = _mouseInputProxy.GetMousePosition() - _camera.WorldToScreenPoint(_unit.position);
            _ship.Rotation(direction);
            _ship.Move(_horizontal, _vertical, deltaTime);
            if (_shiftDown)
                _ship.AddAcceleration();
            if (_shiftUp)
                _ship.RemoveAcceleration();
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisChange;
            _shiftInputProxy.KeyOnChangeDown -= KeyOnChangeDown;
            _shiftInputProxy.KeyOnChangeUp -= KeyOnChangeUp;
        }
    }
}