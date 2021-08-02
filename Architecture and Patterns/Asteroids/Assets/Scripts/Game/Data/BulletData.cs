using System.Linq;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "Data/Unit/BulletSettings")]
    public sealed class BulletData : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField, Range(0, 10)] private float _force;
        [SerializeField] private int numberOfBullets;
        public float Force => _force;
        public Sprite Sprite => sprite;
        public int NumberOfBullets => numberOfBullets;
    }
}
