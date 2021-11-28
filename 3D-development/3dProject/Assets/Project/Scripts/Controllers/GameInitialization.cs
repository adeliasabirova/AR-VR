﻿using UnityEngine;

namespace Game
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
            var firefliesInitialization = new ObjectInitialization(data.FirefliesData.Fireflies, data.FirefliesData.Position);
            var cloudsInitialization = new ObjectInitialization(data.CLoudsData.Clouds, data.CLoudsData.Position);
            var enemyInitalization = new EnemyInitalization(data.EnemyData);
            var playerMoveController = new PlayerMoveController(playerInitialization.GetPlayer(), playerInitialization.ObjectTransform, data.PlayerBody, inputInitialization.GetInput(), camera);

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
            controllers.Add(new AnimatorIKController(playerInitialization.ObjectTransform, playerInitialization.GetPlayer(), enemyInitalization.GetEnemies()));
            //controllers.Add(new RagdollEnemyController(enemyInitalization.GetEnemies(), playerInitialization.ObjectTransform));

        }
    }
}