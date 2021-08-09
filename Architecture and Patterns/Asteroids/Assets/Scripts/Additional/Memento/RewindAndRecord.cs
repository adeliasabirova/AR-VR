using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Additional
{
    internal sealed class RewindAndRecord
    {
        private List<PointInTime> _pointsInTime;
        private Transform _transform;
        private bool _isRewinding;
        private Rigidbody _rb;
        private float _recordTime;

        public RewindAndRecord(Transform transform, Rigidbody rb, float recordTime)
        {
            _transform = transform;
            _rb = rb;
            _recordTime = recordTime;
            _pointsInTime = new List<PointInTime>();
        }

        public bool IsRewinding => _isRewinding;
        public void Rewind()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }
        public void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }

            _pointsInTime.Insert(0, new PointInTime(_transform.position, _transform.rotation, _rb.velocity, _rb.angularVelocity));
        }
        public void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }

        public void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
            _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
        }
    }
}