using System;
using UnityEngine;

namespace Game
{
    internal sealed class CameraController : ILateExecute, IInitialize, ICleanUp
    {
        private readonly Transform _target;
        private readonly Transform _camera;
        private Vector3 _offset;
        private readonly CameraData _cameraData;
        private IUserInputProxy _mouseXInputProxy;
        private float _mouseX;
        private IUserInputProxy _mouseYInputProxy;
        private float _mouseY;


        public CameraController(CameraData cameraData, Transform target, Transform camera, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX, IUserInputProxy inputMouseY, IUserButtonInputProxy inputJump) input)
        {
            _cameraData = cameraData;
            _target = target;
            _camera = camera;
            _mouseXInputProxy = input.inputMouseX;
            _mouseYInputProxy = input.inputMouseY;
        }

        public void Initialize()
        {
            _mouseXInputProxy.AxisOnChange += MouseXOnAxisChange;
            _mouseYInputProxy.AxisOnChange += MouseYOnAxisChange;
            _offset = _camera.position - _target.position;
        }

        private void MouseYOnAxisChange(float obj)
        {
            _mouseY = obj;
        }

        private void MouseXOnAxisChange(float obj)
        {
            _mouseX = obj;
        }

        public void LateExecute(float deltaTime)
        {
            _offset = Quaternion.AngleAxis(_cameraData.SpeedHorizontal * _mouseX, Vector3.up) * Quaternion.AngleAxis(_cameraData.SpeedVertical * _mouseY, Vector3.right) * _offset;
            _camera.position = _target.position + _offset;
            _camera.LookAt(_target.position);
        }

        public void CleanUp()
        {
            _mouseXInputProxy.AxisOnChange -= MouseXOnAxisChange;
        }
    }
}