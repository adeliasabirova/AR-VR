using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        private ModificationWeapon _modificationWeapon;
        private Weapon _weapon;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _weapon = new Weapon(ammunition, _barrelPosition, 999.0f,
            _audioSource, _audioClip);
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler,
            _barrelPosition, _muffler);
            _modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            _modificationWeapon.ApplyModification(_weapon);
            _fire = _modificationWeapon;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if(Time.time > 3.0f)
            {
                _modificationWeapon.DeleteModification(_weapon, _audioClip, _barrelPosition);
            }
        }

    }
}