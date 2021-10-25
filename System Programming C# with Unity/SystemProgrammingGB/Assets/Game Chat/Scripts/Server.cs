using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace GameChat
{
    internal sealed class Server
    {
        private int _hostID;
        private int _reliableChannel;
        private bool _isStarted = false;
        private byte _error;
        
        Dictionary<int, string> _clientTokens = new Dictionary<int, string>();

        public bool IsStarted => _isStarted;
        public int ServerHostID => _hostID;
        public byte Error
        {
            get => _error;
            set => _error = value;
        }

        public void SendClientToServer(int clientId, string name)
        {
            _clientTokens.Add(clientId, name);
        }

        public void StartServer()
        {
            NetworkTransport.Init();

            ConnectionConfig cc = new ConnectionConfig();
            _reliableChannel = cc.AddChannel(QosType.Reliable);
            HostTopology topology = new HostTopology(cc, ConstantValues.MAX_CONNECTION);
            _hostID = NetworkTransport.AddHost(topology, ConstantValues.SERVER_PORT);

            _isStarted = true;
        }

        public void ShutDownServer()
        {
            if (!_isStarted) return;

            NetworkTransport.RemoveHost(_hostID);
            NetworkTransport.Shutdown();
            _isStarted = false;
        }

        public void ReceivedEventServer(NetworkEventType recData, int connectionId, byte[] recBuffer, int dataSize)
        {
            string name = " ";
            if (_clientTokens.TryGetValue(connectionId, out name))
            {
                switch (recData)
                {

                    case NetworkEventType.Nothing:
                        break;

                    case NetworkEventType.ConnectEvent:

                        SendMessageToAll($"Player {name} has connected.");
                        Debug.Log($"Player {name} has connected.");
                        break;

                    case NetworkEventType.DataEvent:
                        string message = Encoding.Unicode.GetString(recBuffer, 0, dataSize);

                        SendMessageToAll($"Player {name}: {message}");
                        Debug.Log($"Player {name}: {message}");
                        break;

                    case NetworkEventType.DisconnectEvent:
                        _clientTokens.Remove(connectionId);

                        SendMessageToAll($"Player {name} has disconnected.");
                        Debug.Log($"Player {name} has disconnected.");
                        break;

                    case NetworkEventType.BroadcastEvent:

                        break;
                }
            }
        }

        

        public void SendMessageToAll(string message)
        {
            foreach (var client in _clientTokens)
            {
                SendMessage(message, client.Key);
            }
        }

        public void SendMessage(string message, int connectionID)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(message);
            NetworkTransport.Send(_hostID, connectionID, _reliableChannel, buffer, message.Length * sizeof(char), out _error);
            if ((NetworkError)_error != NetworkError.Ok) Debug.Log((NetworkError)_error);
        }
    }
}