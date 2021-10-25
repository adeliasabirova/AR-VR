using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameChat
{
    internal sealed class UIController : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonStartServer;
        [SerializeField]
        private Button _buttonShutDownServer;
        [SerializeField]
        private Button _buttonConnectClient;
        [SerializeField]
        private Button _buttonDisconnectClient;
        [SerializeField]
        private Button _buttonSendMessage;

        [SerializeField]
        private TMP_InputField _inputField;

        [SerializeField]
        private TMP_InputField _clinetName;


        [SerializeField]
        private TextField _textField;

        [SerializeField]
        private ServerClient _serverClient;

        private void Start()
        {
            _buttonStartServer.onClick.AddListener(() => StartServer());
            _buttonShutDownServer.onClick.AddListener(() => ShutDownServer());
            _buttonConnectClient.onClick.AddListener(() => Connect());
            _buttonDisconnectClient.onClick.AddListener(() => Disconnect());
            _buttonSendMessage.onClick.AddListener(() => SendMessage());
        }

        private void StartServer()
        {
            _serverClient.StartServer();
        }

        private void ShutDownServer()
        {
            _serverClient.ShutDownServer();
        }

        private void Connect()
        {
            _serverClient.Connect(_clinetName.text);
            _serverClient.Client.onMessageReceive += ReceiveMessage;
        }

        private void Disconnect()
        {
            _serverClient.Disconnect();
        }

        private void SendMessage()
        {
            _serverClient.Client.SendMessage(_inputField.text);
            _inputField.text = "";
        }

        public void ReceiveMessage(object message)
        {
            _textField.ReceiveMessage(message);
        }
    }
}