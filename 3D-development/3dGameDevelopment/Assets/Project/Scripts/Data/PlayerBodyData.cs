using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "PlayerBodyData", menuName = "Data/Unit/PlayerBodyData")]
    public sealed class PlayerBodyData : ScriptableObject
    {
        [SerializeField] private Transform _playerBodyPrefab;
        [SerializeField] private float _power;
        [SerializeField] private bool _useTorque;
        [SerializeField] private float _angularVelocity;
        [SerializeField] private float _healthPoints;
        [SerializeField] private float _scale;
        [SerializeField] private float _speed;

        public float Power => _power;
        public bool UseTorque => _useTorque;
        public float AngularVelocity => _angularVelocity;
        public float HealthPoints => _healthPoints;
        public float Scale => _scale;
        public float Speed => _speed;

        public Transform GetPrefab()
        {
            return _playerBodyPrefab;
        }
    }
}