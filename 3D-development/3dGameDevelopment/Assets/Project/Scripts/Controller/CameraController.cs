using UnityEngine;

namespace Project
{
    internal sealed class CameraController : ILateExecute
    {
        private readonly Transform _target;
        private readonly Transform _camera;
        private readonly Vector3 _offset;

        public CameraController(Transform target, Transform camera)
        {
            _target = target;
            _camera = camera;
            _offset = _camera.position - _target.position;
        }

        public void LateExecute(float deltaTime)
        {
            _camera.position = _target.position + _offset;
        }
    }
}
