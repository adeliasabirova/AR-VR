using UnityEngine;
namespace Project
{
    internal sealed class FirefliesInitialization : IInitialize
    {
        private readonly FirefliesData _firefliesData;
        private ParticleSystem _fireflies;

        public FirefliesInitialization(FirefliesData firefliesData)
        {
            _firefliesData = firefliesData;
            _fireflies = Object.Instantiate(_firefliesData.Fireflies);
        }

        public void Initialize()
        {
        }

        public ParticleSystem Fireflies => _fireflies;
    }
}
