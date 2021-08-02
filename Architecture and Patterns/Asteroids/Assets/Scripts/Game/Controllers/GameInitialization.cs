using UnityEngine;

namespace Asteroids
{
    internal sealed class GameInitialization
    {
        private int _enemyCapacity = 5;
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);
            var bulletObjectPool = new BulletObjectPool(data.Bullet);
            var enemyObjectPool = new EnemyObjectPool(data.Enemies.GetEnemy(EnemyType.Asteroid).gameObject, _enemyCapacity, camera);
            var enemyFactory = new EnemyFactory(data.Enemies);
            var enemyInitialization = new EnemuInitialization(enemyFactory, enemyObjectPool, data.Enemies, camera, _enemyCapacity);
            var bulletInitialization = new BulletInitialization(bulletObjectPool, playerInitialization.GetPlayer().GetTransform().GetChild(0).GetChild(0), inputInitialization.GetInput());
            var unlockAmmunition = new UnlockAmmunition(true);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(playerInitialization.GetPlayer().GetTransform(), data.Player, inputInitialization.GetInput(), camera));
            controllers.Add(new CameraController(playerInitialization.GetPlayer().GetTransform(), camera.transform));
            controllers.Add(bulletInitialization);
            controllers.Add(unlockAmmunition);
            controllers.Add(new BulletInitializationProxy(bulletInitialization, unlockAmmunition));
            controllers.Add(enemyInitialization);
            controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemy(), enemyInitialization.GetEnemies(), enemyInitialization.GetListEnemis(), enemyInitialization.GetCompositeMove(), playerInitialization.GetPlayer().GetTransform().position));
        }

    }
}
