using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "CloudsData", menuName = "Data/Unit/CloudsData")]
    public sealed class CloudsData : ScriptableObject
    {
        [SerializeField] private float _startSize = 75f;
        [SerializeField] private float _startSpeed = 0.1f;
        [SerializeField] private float _startLifeTime = 10f;
        [SerializeField] private float _rateOverTime = 10f;
        [SerializeField] private float _shapeRadius;
        [SerializeField] private Vector3 _scaleBox;
        [SerializeField] private ParticleSystemShapeType _shapeType;
        [SerializeField] private Gradient _color;
        [SerializeField] private float _strength = 0.5f;
        [SerializeField] private float _frequency = 0.8f;
        [SerializeField] private Transform _clouds;
        [SerializeField] private float _minParticleSize;
        [SerializeField] private float _maxParticleSize;
        [SerializeField] private Vector3 _position;

        public Transform Clouds => _clouds;
        public float StartSize => _startSize;
        public float StartSpeed => _startSpeed;
        public float StartLifeTime => _startLifeTime;
        public float RateOverTime => _rateOverTime;
        public float ShapeRadius => _shapeRadius;
        public float Strength => _strength;
        public float Frequency => _frequency;
        public Gradient Color => _color;
        public ParticleSystemShapeType ShapeType => _shapeType;
        public Vector3 ScaleBox => _scaleBox;
        public float MinParticleSize => _minParticleSize;
        public float MaxParticleSize => _maxParticleSize;
        public Vector3 Position => _position;
    }
}