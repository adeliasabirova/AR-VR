using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "LightingData", menuName = "Data/Tools/LightingData")]
    public sealed class LightingData : ScriptableObject
    {
        [SerializeField] private float _fullDayLength;
        [SerializeField] private float _startTime;
        [SerializeField] private Vector3 _noon;
        [SerializeField] private float _lightingOffset;

        public float FullDayLength => _fullDayLength;
        public float StartTime => _startTime;
        public Vector3 Noon => _noon;
        public float LightingOffset => _lightingOffset;

        [Header("Sun")]
        [SerializeField] private Transform _sun;
        [SerializeField] private Gradient _sunColor;
        [SerializeField] private AnimationCurve _sunIntensity;

        public Transform Sun => _sun;
        public Gradient SunColor => _sunColor;
        public AnimationCurve SunIntensity => _sunIntensity;

        [Header("Moon")]
        [SerializeField] private Transform _moon;
        [SerializeField] private Gradient _moonColor;
        [SerializeField] private AnimationCurve _moonIntensity;

        public Transform Moon => _moon;
        public Gradient MoonColor => _moonColor;
        public AnimationCurve MoonIntensity => _moonIntensity;

        [Header("Other Settings")]
        [SerializeField] private AnimationCurve _lightingIntensityMultiplier;
        [SerializeField] private AnimationCurve _reflectionsIntensityMultiplier;

        public AnimationCurve LightingIntensityMultiplier => _lightingIntensityMultiplier;
        public AnimationCurve ReflectionsIntensityMultiplier => _reflectionsIntensityMultiplier;
    }
}