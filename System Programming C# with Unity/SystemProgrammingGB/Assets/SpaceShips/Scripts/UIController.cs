using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShips
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button _buttonEnter;
        [SerializeField] private TMP_InputField _playerName;
        [SerializeField] private SolarSystemNetworkManager _networkManager;

        private void Start()
        {
            _buttonEnter.onClick.AddListener(() => EnterName());
        }

        private void EnterName()
        {
            _networkManager.Instantiate(_playerName.text);
        }
    }
}
