using UnityEngine;

namespace Project
{
    internal sealed class Movement: IMove
    {
        private readonly PlayerBodyData _playerData;
        private Rigidbody _playerRigidbody;

        public Movement(PlayerBodyData playerData, Rigidbody playerRigidbody)
        {
            _playerData = playerData;
            _playerRigidbody = playerRigidbody;
            _playerRigidbody.maxAngularVelocity = _playerData.AngularVelocity;
        }

        public void Move(Vector3 direction)
        {
            if (_playerData.UseTorque)
            {
                _playerRigidbody.AddTorque(new Vector3(direction.z, 0, -direction.x) * _playerData.Power);
            }
            else
            {
                _playerRigidbody.AddForce(direction * _playerData.Power);
            }
        }
    }
}