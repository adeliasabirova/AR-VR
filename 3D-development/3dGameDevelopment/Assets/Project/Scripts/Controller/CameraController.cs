using System;
using UnityEngine;

namespace Project
{
    internal sealed class CameraController : ILateExecute, IInitialize, ICleanUp
    {
        private readonly Transform _target;
        private readonly Transform _camera;
        private Vector3 _offset;
        private readonly CameraData _cameraData;
        private IUserInputProxy _mouseXInputProxy;
        private float _mouseX;

        public CameraController(CameraData cameraData, Transform target, Transform camera, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputMouseX, IUserButtonInputProxy inputJump) input)
        {
            _cameraData = cameraData;
            _target = target;
            _camera = camera;
            _mouseXInputProxy = input.inputMouseX;
        }

        public void Initialize()
        {
            _mouseXInputProxy.AxisOnChange += MouseXOnAxisChange;
            _offset = _camera.position - _target.position;
        }

        private void MouseXOnAxisChange(float obj)
        {
            _mouseX = obj;
        }

        public void LateExecute(float deltaTime)
        {
            _offset = Quaternion.AngleAxis(_cameraData.SpeedHorizontal * _mouseX, Vector3.up) * _offset;
            _camera.position = _target.position + _offset;
            _camera.LookAt(_target.position);
        }

        public void CleanUp()
        {
            _mouseXInputProxy.AxisOnChange -= MouseXOnAxisChange;
        }
    }
}
