using UnityEngine;

namespace Project
{
    internal sealed class PlayerInitialization: IInitialize
    {
        private readonly PlayerBodyData _playerData;
        private Transform _playerTransform;

        public PlayerInitialization(PlayerBodyData playerBodyData, Vector3 position)
        {
            _playerData = playerBodyData;
            var player = Object.Instantiate(_playerData.GetPrefab());
            player.transform.position = position;
            _playerTransform = player.transform;
        }

        public void Initialize()
        {
            
        }

        public Transform PlayerTransform => _playerTransform;
    }
}
