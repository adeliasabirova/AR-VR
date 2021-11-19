using UnityEngine;

namespace Project
{
    internal sealed class PlayerInitialization: IInitialize
    {
        private readonly PlayerBodyData _playerData;

        private Transform _objectTransform;
        private Transform _bodyTransform;

        public PlayerInitialization(PlayerBodyData playerData, Vector3 position, float scale)
        {
            _playerData = playerData;
            _objectTransform = Object.Instantiate(_playerData.GetPrefab());
            _objectTransform.position = position;
            _objectTransform.localScale *= scale;
            _bodyTransform = _objectTransform.GetChild(0);
        }

        public void Initialize()
        {
        }

        public Transform ObjectTransform => _objectTransform;
        public Transform BodyTransform => _bodyTransform;

        public Player GetPlayer()
        {
            return _objectTransform.GetComponent<Player>();
        }
    }
}
