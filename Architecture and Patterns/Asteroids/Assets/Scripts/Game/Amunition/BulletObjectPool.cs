using UnityEngine;

namespace Asteroids
{
    public sealed class BulletObjectPool : IBulletObjectPool
    {
        private readonly BulletData _data;
        private ViewService _viewService;
        private int _currentBulletID;

        public ViewService ViewService => _viewService;

        public BulletObjectPool(BulletData data)
        {
            _data = data;
            _viewService = new ViewService(data.NumberOfBullets);
            _currentBulletID = 0;
        }

        public IBullet CreateBullet(Vector3 position, Quaternion rotation, Vector3 direction)
        {
            if (_currentBulletID == _viewService.Capacity)
            {
                _currentBulletID = 0;
            }

            var bulletGameObject = _viewService.GetGameObject(_currentBulletID);
            if (bulletGameObject == null)
            {
                var prefab = new GameObject().SetName("Bullet").AddBoxCollider2D(Vector2.zero, new Vector2(0.1f, 0.2f))
                    .AddTransform(new Vector3(0.5f, 1f, 1f)).AddSprite(_data.Sprite, Color.yellow).AddRigidbody2D(1f, 0f).AddScript("BulletAmmunition");
                bulletGameObject = _viewService.Create(_currentBulletID, prefab, false);
            }

            var bullet = bulletGameObject.GetComponent<BulletAmmunition>();
            bullet.Initiate(_viewService, bulletGameObject, _currentBulletID);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * _data.Force, ForceMode2D.Impulse);
            _currentBulletID += 1;

            return bullet;
        }
    }
}