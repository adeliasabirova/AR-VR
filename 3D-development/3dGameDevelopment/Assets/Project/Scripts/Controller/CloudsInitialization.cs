using UnityEngine;
namespace Project
{
    internal sealed class CloudsInitialization : IInitialize
    {
        private readonly CloudsData _cloudsData;
        private Transform _clouds;

        public CloudsInitialization(CloudsData cloudsData)
        {
            _cloudsData = cloudsData;
            _clouds = Object.Instantiate(_cloudsData.Clouds);
        }

        public void Initialize()
        {
        }

        public Transform Clouds => _clouds;
    }
}
