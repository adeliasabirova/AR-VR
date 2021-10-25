using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace GameChat
{
    internal sealed class Client
    {
        public delegate void OnMessageReceive(object message);
        public event OnMessageReceive onMessageReceive;

        private int _hostID;
        private int _reliableChannel;
        private int _connectionID;
        private bool _isConnected = false;
        private byte _error;
        private string _clientName;

        public bool IsConnected => _isConnected;
        public int ClientHostID => _hostID;

        public byte Error
        {
            get => _error;
            set => _error = value;
        }

        public void CreateClient(string name)
        {
            _clientName = name;
        }


        public void Connect()
        {
            NetworkTransport.Init();
            ConnectionConfig cc = new ConnectionConfig();

            _reliableChannel = cc.AddChannel(QosType.Reliable);

            HostTopology topology = new HostTopology(cc, ConstantValues.MAX_CONNECTION);

            _hostID = NetworkTransport.AddHost(topology, ConstantValues.CLIENT_PORT);
            _connectionID = NetworkTransport.Connect(_hostID, ConstantValues.IP_ADDRESS, ConstantValues.SERVER_PORT, 0, out _error);

            if ((NetworkError)_error == NetworkError.Ok)
                _isConnected = true;
            else
                Debug.Log((NetworkError)_error);
        }

        public void Disconnect()
        {
            if (!_isConnected) return;
            NetworkTransport.Disconnect(_hostID, _connectionID, out _error);
            _isConnected = false;
        }

        public void ReceivedEventClient(NetworkEventType recData, byte[] recBuffer, int dataSize)
        {
            switch (recData)
            {
                case NetworkEventType.Nothing:
                    break;

                case NetworkEventType.ConnectEvent:
                    onMessageReceive?.Invoke($"You have been connected to server.");
                    Debug.Log($"You have been connected to server.");
                    break;

                case NetworkEventType.DataEvent:
                    string message = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                    onMessageReceive?.Invoke(message);
                    Debug.Log(message);
                    break;

                case NetworkEventType.DisconnectEvent:
                    _isConnected = false;
                    onMessageReceive?.Invoke($"You have been disconnected from server.");
                    Debug.Log($"You have been disconnected from server.");
                    break;

                case NetworkEventType.BroadcastEvent:

                    break;
            }
        }

        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(message);
            NetworkTransport.Send(_hostID, _connectionID, _reliableChannel, buffer, message.Length * sizeof(char), out _error);
            if ((NetworkError)_error != NetworkError.Ok) Debug.Log((NetworkError)_error);
        }
    }
}
