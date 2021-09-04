using UnityEngine;

namespace Arkanoid
{

    internal sealed class BallView : MonoBehaviour, IView
    {
        [SerializeField] private float _speed = 10.0f;
        private IViewModelDirection _ball;
        private Rigidbody2D _rb;

        public void Initialize()
        {
            _rb = GetComponent<Rigidbody2D>();
            _ball = new BallViewModel(_speed, Vector2.up, _rb);
        }

        public void Movement()
        {
            _ball.Movement(1.0f);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent<RacketView>(out var component))
            {
                _ball.DirectionChanged(transform.position, component.transform.position, collision.collider.bounds.size.x);
                Movement();
            }
        }
    }
}