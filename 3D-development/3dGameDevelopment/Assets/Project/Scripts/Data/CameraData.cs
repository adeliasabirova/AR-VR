using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName ="CameraData", menuName ="Data/Tools/CameraData")]
    public sealed class CameraData : ScriptableObject
    {
        [SerializeField] private float _speedHorizontal;
        [SerializeField] private float _speedVertical;

        public float SpeedHorizontal => _speedHorizontal;
        public float SpeedVertical => _speedVertical;
    }
}