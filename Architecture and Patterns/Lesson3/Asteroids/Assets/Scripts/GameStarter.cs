using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private EnemyPool _enemyPool;
        private Camera _camera;

        private void Awake()
        {
            _enemyPool = new EnemyPool(5);
            _camera = Camera.main;
        }

        private void Start()
        {
            InvokeRepeating("CreateComet", 5.0f, 5.0f);
            InvokeRepeating("CreateEnemyShip", 10.0f, 10.0f);
            InvokeRepeating("CreateAsteroids", .5f, .5f);

        }
        private Enemy CreateComet()
        {
            var enemy = Enemy.CreateComet(new Health(100.0f, 100.0f));
            enemy.transform.position = new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f);
            return enemy;
        }

        private Enemy CreateEnemyShip()
        {
            IEnemyFactory factory = new EnemyShipFactory();
            var enemy = factory.Create(new Health(100.0f, 100.0f));
            enemy.transform.position = new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, Random.Range(-5f, 1f) + +_camera.transform.position.y, 0f);
            return enemy;
        }

        private Enemy CreateAsteroids()
        {
            var enemy = _enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = new Vector3(Random.Range(-5f, 5f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f);
            enemy.gameObject.SetActive(true);
            return enemy;
        }


    }
}