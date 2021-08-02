using System;
using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletInitialization : IInitialize, ICleanup
    {
        private readonly IBulletObjectPool _bulletObjectPool;
        private readonly Transform _unit;
        private IUserMouseInputProxy _mouseInputProxy;
        private bool _fireDown;

        public BulletInitialization(IBulletObjectPool bulletObjectPool, Transform unit, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserMouseInputProxy inputFire, IUserKeyInputProxy inputShift) input)
        {
            _bulletObjectPool = bulletObjectPool;
            _unit = unit;
            _mouseInputProxy = input.inputFire;
            
        }

        public void Initialize()
        {
            _mouseInputProxy.MouseButtonOnChangeDown += MouseButtonDownOnChange;
        }
        private void MouseButtonDownOnChange(bool obj)
        {
            _fireDown = obj;
        }

        public void Execute(float deltaTime)
        {
            if (_fireDown)
                _bulletObjectPool.CreateBullet(_unit.position, _unit.rotation, _unit.up);
        }

        public void Cleanup()
        {
            _mouseInputProxy.MouseButtonOnChangeDown -= MouseButtonDownOnChange;
        }
    }
}