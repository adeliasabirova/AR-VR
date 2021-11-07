using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "FirefliesData", menuName = "Data/Unit/FirefliesData")]
    public sealed class FirefliesData : ScriptableObject
    {
        [SerializeField] private float _startSize = 0.5f;
        [SerializeField] private float _startSpeed = 0f;
        [SerializeField] private float _rateOverTime = 20f;
        [SerializeField] private float _shapeRadius;
        [SerializeField] private Vector3 _scaleBox;
        [SerializeField] private ParticleSystemShapeType _shapeType;
        [SerializeField] private Gradient _color;
        [SerializeField] private ParticleSystem.MinMaxCurve _curve;
        [SerializeField] private float _strength = 0.5f;
        [SerializeField] private float _frequency = 0.8f;
        [SerializeField] private ParticleSystem _fireflies;

        public ParticleSystem Fireflies => _fireflies;
        public float StartSize => _startSize;
        public float StartSpeed => _startSpeed;
        public float RateOverTime => _rateOverTime;
        public float ShapeRadius => _shapeRadius;
        public float Strength => _strength;
        public float Frequency => _frequency;
        public ParticleSystem.MinMaxCurve Curve => _curve;
        public Gradient Color => _color;
        public ParticleSystemShapeType ShapeType => _shapeType;
        public Vector3 ScaleBox => _scaleBox;
    }
}