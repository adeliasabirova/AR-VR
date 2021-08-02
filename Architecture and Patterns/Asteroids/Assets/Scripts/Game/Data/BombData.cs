using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "BombSettings", menuName = "Data/Unit/BombSettings")]
    public sealed class BombData : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField, Range(0, 10)] private float _explodeTime;
        public float ExplodeTime => _explodeTime;
        public Sprite Sprite => sprite;
    }
}