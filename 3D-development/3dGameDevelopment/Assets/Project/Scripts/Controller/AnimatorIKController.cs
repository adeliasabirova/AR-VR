using System.Collections.Generic;
using UnityEngine;
namespace Project
{
    internal sealed class AnimatorIKController : IInitialize, ICleanUp
    {
        private Animator _animator;
        private readonly Transform _transform;
        private IPlayer _player;
        private IEnumerable<Transform> _targets;

        public AnimatorIKController(Transform transform, IPlayer player, IEnumerable<Transform> targets)
        {
            _transform = transform;
            _player = player;
            _targets = targets;
        }

        public void Initialize()
        {
            _animator = _transform.GetComponent<Animator>();
            _player.OnAnimatorIKChange += AnimatorIKChange;
        }


        private void AnimatorIKChange(int obj)
        {
            foreach (var target in _targets)
            {
                if (target != null)
                {
                    if (Vector3.Distance(_transform.position, target.position) <= 2.0f * _transform.localScale.x)
                    {
                        _animator.SetLookAtWeight(1);
                        _animator.SetLookAtPosition(target.position);

                        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

                        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                        _animator.SetIKPosition(AvatarIKGoal.RightHand, target.position);
                        _animator.SetIKPosition(AvatarIKGoal.LeftHand, target.position);

                        _animator.SetIKRotation(AvatarIKGoal.RightHand, target.rotation);
                        _animator.SetIKRotation(AvatarIKGoal.LeftHand, target.rotation);
                    }
                }
                else
                {
                    _animator.SetLookAtWeight(0);

                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);

                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                }
            }
        }

        public void CleanUp()
        {
            _player.OnAnimatorIKChange -= AnimatorIKChange;
        }
    }
}
