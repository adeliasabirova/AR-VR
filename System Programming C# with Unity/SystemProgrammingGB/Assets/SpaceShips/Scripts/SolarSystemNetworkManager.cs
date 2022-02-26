using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SpaceShips
{

    public class SolarSystemNetworkManager : NetworkManager
    {
        [SerializeField] private InputField _input;
        [SyncVar] private string _name;

        [Command]
        private void CmdSetName(string name)
        {
            _name = name;
        }

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
            SetPort();
            base.StartHost();
            
        }

        public void JoinGame()
        {
            SetIPAdress();
            SetPort();
            base.StartClient();
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            CmdSetName(_input.text);
            base.OnServerConnect(conn);
        }


        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            var spawnTransform = GetStartPosition();

            var player = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
            player.GetComponent<ShipController>().RpcSetInput(_name);
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