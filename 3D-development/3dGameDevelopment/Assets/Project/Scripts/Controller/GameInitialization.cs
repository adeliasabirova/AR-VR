using UnityEngine;
namespace Project
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data, Vector3 startPosition)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerInitialization = new PlayerInitialization(data.PlayerBody, startPosition);
            var healthController = new HealthController(data.PlayerBody);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new CameraController(data.CameraData, playerInitialization.PlayerTransform, camera.transform, inputInitialization.GetInput()));
            controllers.Add(new PlayerMoveController(playerInitialization.PlayerTransform, data.PlayerBody, inputInitialization.GetInput(), camera));
            controllers.Add(healthController);
            controllers.Add(new PlayerDataController(playerInitialization.PlayerTransform, healthController));
        }
    }
}
