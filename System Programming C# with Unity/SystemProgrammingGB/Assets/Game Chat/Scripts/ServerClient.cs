using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace GameChat
{
    internal sealed class ServerClient: MonoBehaviour
    {
        private Server _server;
        private Client _client;
        private List<Client> _clients;

        public Client Client => _client;

        private void Start()
        {
            _server = new Server();
            //_clients = new List<Client>();
            _client = new Client();
        }

        public void StartServer()
        {
            _server.StartServer();
        }

        public void ShutDownServer()
        {
            _server.ShutDownServer();
        }

        public void Connect(string name)
        {
            _client.CreateClient(name);
            _client.Connect();
            _server.SendClientToServer(_client.ClientHostID, name);
            //_clients.Add(_client);
        }

        public void Disconnect()
        {
            _client.Disconnect();
        }

        void Update()
        {
            if (!_server.IsStarted) return;

            int recHostId;
            int connectionId;
            int channelId;
            byte[] recBuffer = new byte[ConstantValues.BUFFER_SIZE];
            int dataSize;
            byte error;

            NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, ConstantValues.BUFFER_SIZE, out dataSize, out error);
            while (recData != NetworkEventType.Nothing)
            {

                if (recHostId == _server.ServerHostID)
                {
                    _server.Error = error;
                    _server.ReceivedEventServer(recData, connectionId, recBuffer, dataSize);
                }
                if(recHostId == _client.ClientHostID)
                {
                    _client.Error = error;
                    _client.ReceivedEventClient(recData, recBuffer, dataSize);
                }
                recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, ConstantValues.BUFFER_SIZE, out dataSize, out error);
            }
            
        }

    }
}