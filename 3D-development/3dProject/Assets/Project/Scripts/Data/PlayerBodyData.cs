using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "PlayerBodyData", menuName = "Data/Unit/PlayerBodyData")]
    public sealed class PlayerBodyData : ScriptableObject
    {
        [SerializeField] private Transform _playerObjectPrefab;
        [SerializeField] private float _jumpPower = 12f;
        [SerializeField] private float _movingTurningSpeed = 360f;
        [SerializeField] private float _standingTurningSpeed = 180f;
        [Range(1f, 4f)] [SerializeField] float _gravityMultiplier = 2f;
        [SerializeField] float _runningCycleLegOffset = 0.2f;
        [SerializeField] float _movingSpeedMultiplier = 1.0f;
        [SerializeField] float _animatorSpeedMultiplier = 1f;
        [SerializeField] float _distanceToGroundCheck = 0.1f;
        [SerializeField] private float _scale;
        [SerializeField] private float _healthPoints;

        public float Power => _jumpPower;
        public float MovingTurningSpeed => _movingTurningSpeed;
        public float StandingTurningSpeed => _standingTurningSpeed;
        public float GravityMultiplier => _gravityMultiplier;
        public float DistanceToGroundCheck => _distanceToGroundCheck;
        public float RunningCycleLegOffset => _runningCycleLegOffset;
        public float MovingSpeedMultiplier => _movingSpeedMultiplier;
        public float AnimatorSpeedMultiplier => _animatorSpeedMultiplier;
        public float Scale => _scale;
        public float HealthPoints => _healthPoints;

        public Transform GetPrefab()
        {
            return _playerObjectPrefab;
        }
    }
}