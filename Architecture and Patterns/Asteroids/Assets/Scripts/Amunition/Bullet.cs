using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Bullet : IBullet
    {
        private float _force = 10;
        private ViewService _viewService;
        private int _currentID = 0;
        private Sprite _sprite;
        public Bullet(ViewService viewService, Sprite sprite)
        {
            _viewService = viewService;
            _sprite = sprite;
        }

        public void Create(Vector3 position, Quaternion rotation, Vector3 direction)
        {
            //var prefab = Resources.Load<GameObject>("Ammunition/Bullet");
            if (_currentID == _viewService.Capacity)
            {
                _currentID = 0;
            }
            var bulletGO = _viewService.GetGameObject(_currentID);
            if (bulletGO == null)
            {
                var prefab = new GameObject().SetName("Bullet").AddBoxCollider2D(Vector2.zero, new Vector2(0.1f, 0.2f))
                    .AddTransform(new Vector3(0.5f, 1f, 1f)).AddSprite(_sprite, Color.yellow).AddRigidbody2D(1f, 0f).AddScript("BulletAmmunition");
                bulletGO = _viewService.Create(_currentID, prefab, false);
            }
            

            var bullet = bulletGO.GetComponent<BulletAmmunition>();
            bullet.Initiate(_viewService, bulletGO, _currentID);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * _force, ForceMode2D.Impulse);
            _currentID += 1;
        }

    }
}