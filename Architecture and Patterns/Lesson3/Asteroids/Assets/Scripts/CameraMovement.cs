using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    internal sealed class CameraMovement : MonoBehaviour
    {
        private Transform _target;
        private Camera _camera;
        private CameraController _cameraController;

        private void Start()
        {
            _camera = Camera.main;
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _cameraController = new CameraController(_target, _camera.transform);
        }

        private void LateUpdate()
        {
            _cameraController.LateExecute(Time.deltaTime);
        }
    }
}