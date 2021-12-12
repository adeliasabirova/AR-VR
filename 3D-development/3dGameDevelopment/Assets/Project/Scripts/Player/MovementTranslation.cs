using UnityEngine;

namespace Project
{
    internal sealed class MovementTranslation : IMove
    {
        public Vector3 Speed { get; private set; }

        public void Move(float horizontal, float vertical, Vector3 cameraRight, Vector3 cameraForward)
        {
            var cameraDirection = Vector3.Scale(cameraForward, new Vector3(1, 0, 1)).normalized;
            Speed = (vertical * cameraDirection + horizontal * cameraRight).normalized;
            if (Speed.magnitude > 1f)
                Speed.Normalize();
        }
    }
}