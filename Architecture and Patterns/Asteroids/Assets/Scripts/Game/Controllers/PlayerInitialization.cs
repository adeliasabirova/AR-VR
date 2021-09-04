using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerInitialization : IInitialize
    {
        private readonly IPlayerFactory _playerFactory;
        private IPlayer _player;

        public PlayerInitialization(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
        }

        public void Initialize()
        {
        }

        public IPlayer GetPlayer()
        {
            return _player;
        }
        public Transform GetBarrelPosition()
        {
            return _playerFactory.GetBarrelPosition();
        }
    }
}