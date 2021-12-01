using UnityEngine;
using UnityEngine.Networking;

namespace SpaceShips
{
    public class SolarSystemNetworkManager : NetworkManager
    {
        private string _playerName;

        public void Instantiate(string name)
        {
            _playerName = name;
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            var spawnTransform = GetStartPosition();

            var player = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
            player.GetComponent<ShipController>().PlayerName = _playerName;
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
    }
}