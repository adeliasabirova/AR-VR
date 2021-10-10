using UnityEngine;

namespace Galaxy
{
    internal sealed class GalaxyStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;

        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new GalaxyInitialization(_controllers, _data);
            _controllers.Initialize();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.CleanUp();
        }
    }
}