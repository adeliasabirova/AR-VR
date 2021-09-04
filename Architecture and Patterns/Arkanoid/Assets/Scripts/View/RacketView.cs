using UnityEngine;

namespace Arkanoid
{

    internal sealed class RacketView : MonoBehaviour, IView
    {
        [SerializeField] private float _speed = 10.0f;
        private IViewModel _racket;
        private Rigidbody2D _rb;

        public void Initialize()
        {
            _rb = GetComponent<Rigidbody2D>();
            _racket = new RacketViewModel(_speed, Vector2.right, _rb);
        }

        public void Movement()
        {
            _racket.Movement(Input.GetAxisRaw("Horizontal"));
        }
    }
}