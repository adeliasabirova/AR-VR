using UnityEngine;

namespace Asteroids.Additional
{
    public sealed class TimeBody : MonoBehaviour
    {
        [SerializeField] private float _recordTime = 5f;
        private Rigidbody _rb;
        private RewindAndRecord _rewind;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rewind = new RewindAndRecord(transform, _rb, _recordTime);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _rewind.StartRewind();
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                _rewind.StopRewind();
            }
        }
        private void FixedUpdate()
        {
            if (_rewind.IsRewinding)
            {
                _rewind.Rewind();
            }
            else
            {
                _rewind.Record();
            }
        }
    }
}