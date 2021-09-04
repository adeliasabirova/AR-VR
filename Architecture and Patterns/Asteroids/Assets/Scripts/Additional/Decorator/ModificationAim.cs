using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationAim : ModificationWeapon
    {
        private readonly IAim _aim;
        private RaycastHit2D _hit;
        private GameObject _aimGameObject;

        public ModificationAim(IAim aim)
        {
            _aim = aim;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            Vector3 _aimPosition = _aim.Position.position + _aim.DistanceFromGun * Vector3.forward;
            _aimGameObject = Object.Instantiate(_aim.AimInstance,
            _aimPosition, Quaternion.identity);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon, AudioClip audioClip, Transform barrelPosition)
        {
            weapon.SetAudioClip(audioClip);
            weapon.SetBarrelPosition(barrelPosition);
            Object.Destroy(_aimGameObject);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(_aimGameObject);
            return weapon;
        }
    }
}