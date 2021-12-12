using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    internal sealed class RagdollEnemyController : IInitialize, IExecute
    {
        private IEnumerable<Transform> _targets;
        private Dictionary<int, List<Collider>> _ragdollColliders;
        private readonly Transform _transform;
        private int _numberOfTargets;

        public RagdollEnemyController(IEnumerable<Transform> targets, Transform transform)
        {
            _targets = targets;
            _transform = transform;
            _ragdollColliders = new Dictionary<int, List<Collider>>();
        }

        private void TurnOffRagdollColliders()
        {
            var i = 0;
            foreach(var target in _targets)
            {
                target.GetComponent<Collider>().enabled = true;
                Collider[] colliders = target.GetComponentsInChildren<Collider>();
                List<Collider> ragdollColliders = new List<Collider>();
                foreach(var collider in colliders)
                {
                    if (collider.gameObject != target.gameObject)
                    {
                        collider.isTrigger = true;
                        ragdollColliders.Add(collider);
                    }
                    else
                    {
                        Debug.Log("collider found");
                    }
                }
                _ragdollColliders.Add(i, ragdollColliders);
                i++;
            }
            _numberOfTargets = i - 1;
        }

        private void TurnOnRagdollColliders(int indexOfTarget)
        {
            var isCollider = _ragdollColliders.TryGetValue(indexOfTarget, out var value);
            if (isCollider)
            {
                foreach(var collider in value)
                {
                    collider.isTrigger = false;
                }
            }
        }

        public void Initialize()
        {
            TurnOffRagdollColliders();
        }

        public void Execute(float deltaTime)
        {
            var i = 0;
            foreach(var target in _targets)
            {
                if (Vector3.Distance(_transform.position, target.position) <= 2.0f * _transform.localScale.x)
                {
                    target.GetComponent<CapsuleCollider>().enabled = false;
                    //target.GetComponent<Animator>().enabled = false;
                    TurnOnRagdollColliders(i);
                }
                i++;
            }
        }
    }
}
