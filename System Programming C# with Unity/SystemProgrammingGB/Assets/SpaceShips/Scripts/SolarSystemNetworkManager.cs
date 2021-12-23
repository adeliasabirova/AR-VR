using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SpaceShips
{
    public class SolarSystemNetworkManager : NetworkManager
    {
        [SerializeField] private InputField _playerName;

        private Dictionary<NetworkConnection, string> _playerDictionary;

        private void SetPort()
        {
            base.networkPort = 7777;
        }

        private void SetIPAdress()
        {
            base.networkAddress = "localhost";
        }

        public void StartHosting()
        {
            _playerDictionary = new Dictionary<NetworkConnection, string>();
            SetPort();
            base.StartHost();
            
        }

        public void JoinGame()
        {
            SetIPAdress();
            SetPort();
            base.StartClient();
        }

        private string SetPlayerName()
        {
            var name = _playerName.text;
            return name;
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            string name = SetPlayerName();
            _playerDictionary.Add(conn, name);
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            var spawnTransform = GetStartPosition();

            var player = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
            _playerDictionary.TryGetValue(conn, out string name);
            player.GetComponent<ShipController>().PlayerName = name;

            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }

        private void OnLevelWasLoaded(int level)
        {
            if (level == 0)
            {
                SetupStartSceneButtons();
            }
            else
            {
                SetupMainSceneButtons();
            }
        }

        private void SetupMainSceneButtons()
        {
            GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(base.StopHost);
        }

        private void SetupStartSceneButtons()
        {
            GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartHosting);
            
            GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);

        }

    }
}