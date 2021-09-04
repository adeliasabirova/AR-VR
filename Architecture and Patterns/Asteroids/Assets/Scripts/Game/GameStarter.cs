using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;
        [SerializeField] private PanelOne _panelOne;
        [SerializeField] private PanelTwo _panelTwo;
        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            var dictionary = new Dictionary<string, BaseUI>
            {
                { "first", _panelOne },
                { "second", _panelTwo }
            };
            new GameInitialization(_controllers, _data, dictionary);
            _controllers.Initialize();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime); 
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }


    }
}