using UnityEngine;

namespace Project
{
    public interface IMove
    {
        public void Move(float horizontal, float vertical, Vector3 cameraRight, Vector3 cameraForward);
    }
}