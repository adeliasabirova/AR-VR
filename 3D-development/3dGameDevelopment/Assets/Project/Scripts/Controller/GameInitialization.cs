using UnityEngine;
namespace Project
{

    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data, Vector3 startPosition)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerInitialization = new PlayerInitialization(data.PlayerBody, startPosition, data.PlayerBody.Scale);
            var healthController = new HealthController(data.PlayerBody);
            var lightingInitialization = new LightingInitialization(data.LightingData);
            var firefliesInitialization = new ObjectInitialization(data.FirefliesData.Fireflies);
            var cloudsInitialization = new ObjectInitialization(data.CLoudsData.Clouds);
            var enemyInitalization = new ObjectInitialization(data.EnemyData.Enemy, data.EnemyData.Position, data.EnemyData.Scale);
            var playerMoveController = new PlayerMoveController(playerInitialization.ObjectTransform, data.PlayerBody, inputInitialization.GetInput(), camera);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new CameraController(data.CameraData, playerInitialization.ObjectTransform, camera.transform, inputInitialization.GetInput()));
            controllers.Add(playerMoveController);
            controllers.Add(healthController);
            controllers.Add(new PlayerDataController(playerInitialization.BodyTransform, healthController));
            controllers.Add(lightingInitialization);
            controllers.Add(new LightingController(data.LightingData, lightingInitialization.Sun, lightingInitialization.Moon));
            controllers.Add(firefliesInitialization);
            controllers.Add(new FirefliesController(data.FirefliesData, firefliesInitialization.ObjectTransform));
            controllers.Add(cloudsInitialization);
            controllers.Add(new CloudsController(data.CLoudsData, cloudsInitialization.ObjectTransform));
            controllers.Add(enemyInitalization);
            GetMovementByPlayer.Controller = playerMoveController;

        }
    }
}
