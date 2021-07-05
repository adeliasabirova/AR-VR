using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private Camera _camera;
        private ViewService _viewService;
        private int capacityEnemy = 5;
        private int _currentEnemyID = 0;
        private Timer _cometTimer;
        private Timer _asteroidTimer;
        private Timer _enemyShipTimer;
        private Enemy _cometCopy;
        private Enemy _enemyShipCopy;

        private void Awake()
        {
            _camera = Camera.main;
            ServiceLocator.SetService<IViewService>(new ViewService(capacityEnemy));
            //_viewService = new ViewService(capacityEnemy);
            _cometTimer = new Timer(5.0f);
            _asteroidTimer = new Timer(0.5f);
            _enemyShipTimer = new Timer(15.0f);
        }

        private void Start()
        {
            //var comet = CreateComet();
            //_cometCopy = comet.DeepCopy<Enemy>();
            //_cometCopy.gameObject.SetActive(false);

        }

        private void Update()
        {
            if (_cometTimer.Tick(Time.deltaTime))
            {
                CreateComet();
                //var enemy = _cometCopy;
                //enemy.gameObject.SetActive(true);
                //_cometCopy = enemy.DeepCopy<Enemy>();
                //_cometCopy.gameObject.SetActive(false);
            }
            if (_asteroidTimer.Tick(Time.deltaTime))
                CreateAsteroids();
            if (_enemyShipTimer.Tick(Time.deltaTime))
                CreateEnemyShip();
        }

        private Enemy CreateComet()
        {
            var enemy = Comet.CreateComet(new Health(100.0f, 100.0f));
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

        private void CreateAsteroids()
        {
            var _prefab = Resources.Load<GameObject>("Enemy/Asteroid");
            if (_currentEnemyID == 5) _currentEnemyID = 0;
            var enemyGO = ServiceLocator.Resolve<IViewService>().Create(_currentEnemyID, _prefab, true);
            var enemy = enemyGO.GetComponent<Asteroid>();
            enemy.Initiate(enemyGO, _currentEnemyID);
            enemy.DependencyInjectHealth(new Health(100.0f, 100.0f));
            enemy.transform.position = new Vector3(Random.Range(-5f, 5f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f);
            _currentEnemyID += 1;
        }
    }
}