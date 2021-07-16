using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        //private Camera _camera;
        //private ViewService _viewService;
        //private int capacityEnemy = 5;
        //private int _currentEnemyID = 0;
        //private Timer _cometTimer;
        //private Timer _asteroidTimer;
        //private Timer _enemyShipTimer;
        //private Enemy _cometCopy;
        //private Enemy _enemyShipCopy;

        private void Awake()
        {
            //_camera = Camera.main;
            //ServiceLocator.SetService<IViewService>(new ViewService(capacityEnemy));
            ////_viewService = new ViewService(capacityEnemy);
            //_cometTimer = new Timer(5.0f);
            //_asteroidTimer = new Timer(0.5f);
            //_enemyShipTimer = new Timer(15.0f);
        }

        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data);
            _controllers.Initialize();
            //var comet = CreateComet();
            //_cometCopy = comet.DeepCopy<Enemy>();
            //_cometCopy.gameObject.SetActive(false);

        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime); 
            //if (_cometTimer.Tick(Time.deltaTime))
            //{
            //    CreateComet();
            //    //var enemy = _cometCopy;
            //    //enemy.gameObject.SetActive(true);
            //    //_cometCopy = enemy.DeepCopy<Enemy>();
            //    //_cometCopy.gameObject.SetActive(false);
            //}
            //if (_asteroidTimer.Tick(Time.deltaTime))
            //    CreateAsteroids();
            //if (_enemyShipTimer.Tick(Time.deltaTime))
            //    CreateEnemyShip();
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

        //private Enemy CreateComet()
        //{
        //    var enemy = Comet.CreateComet(new Health(100.0f, 100.0f));
        //    enemy.transform.position = new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, 5f + _camera.transform.position.y, 0f);
        //    return enemy;
        //}

        //private Enemy CreateEnemyShip()
        //{
        //    IEnemyFactory factory = new EnemyShipFactory();
        //    var enemy = factory.Create(new Health(100.0f, 100.0f));
        //    enemy.transform.position = new Vector3(Random.Range(-5f, 1f) + _camera.transform.position.x, Random.Range(-5f, 1f) + +_camera.transform.position.y, 0f);
        //    return enemy;
        //}

    }
}