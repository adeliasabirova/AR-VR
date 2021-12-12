using UnityEngine;

namespace Game
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;

        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data, transform.position);
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
            _controllers.CleanUp();
        }

        private void OnGUI()
        {
            _controllers.Gui();
        }

    }
}