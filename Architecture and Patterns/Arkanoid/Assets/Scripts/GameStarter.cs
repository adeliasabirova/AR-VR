using UnityEngine;

namespace Arkanoid
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private IView _racket;
        private IView _ball;
        private RacketFabric _racketFabric;
        private BallFabric _ballFabric;

        private void Awake()
        {
            _racketFabric = new RacketFabric();
            _ballFabric = new BallFabric();
        }
        private void Start()
        {
            new BackgroundFabric();

            _racket = _racketFabric.Create(new Vector3(0, -4, 0), new Quaternion());
            _racket.Initialize();

            _ball = _ballFabric.Create(new Vector3(0, -3, 0), new Quaternion());
            _ball.Initialize();
            _ball.Movement();
        }

        private void FixedUpdate()
        {
            _racket.Movement();
            
        }
    }
}