using System;
using UnityEngine;

namespace Galaxy
{
    [CreateAssetMenu(fileName = "CelestialBodyData", menuName = "Data/Unit/CelestialBodyData")]
    public sealed class CelestailBodyData : ScriptableObject
    {
        [SerializeField] private GameObject _celestialBodyPrefab;
        [SerializeField] private float _startVelocity;
        [SerializeField] private float _startDistance;
        [SerializeField] private float _startMass;
        [SerializeField] private float _gravitationalModifier;

        public float StartVelocity => _startVelocity;
        public float StartDistance => _startDistance;
        public float StartMass => _startMass;
        public float GravitationalModifier => _gravitationalModifier;

        public GameObject GetPrefab()
        {
            return _celestialBodyPrefab;
        }
    }
}