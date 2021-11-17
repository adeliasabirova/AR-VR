using UnityEngine;
namespace Project
{
    internal sealed class AnimatorIKController : MonoBehaviour
    {
        private Animator _animator;
        private Transform _target;

        private void Start()
        {
            _animator = transform.GetComponent<Animator>();
            _target = GameObject.FindGameObjectsWithTag("Enemy")[0].transform;
        }

        private void OnAnimatorMove()
        {
            GetMovementByPlayer.AnimatorMove(Time.deltaTime);
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if (_target != null)
            {
                if (Vector3.Distance(transform.position, _target.position) <= 2.0f * transform.localScale.x)
                {
                    _animator.SetLookAtWeight(1);
                    _animator.SetLookAtPosition(_target.position);

                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                    _animator.SetIKPosition(AvatarIKGoal.RightHand, _target.position);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _target.position);

                    _animator.SetIKRotation(AvatarIKGoal.RightHand, _target.rotation);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _target.rotation);
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
}
