using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public IPlayer CreatePlayer()
        {
            var player = Object.Instantiate(_playerData.GetPlayer());
            var playerComponent = player.GetComponent<Player>();
            playerComponent.Health = new Health(100.0f, 100.0f);
            return player;
        }
    }
}