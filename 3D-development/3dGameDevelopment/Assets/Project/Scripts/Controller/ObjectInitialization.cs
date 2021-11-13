using UnityEngine;

namespace Project
{
    internal sealed class ObjectInitialization: IInitialize
    {
        private Transform _objectTransform;

        public ObjectInitialization(Transform objectTransform)
        {
            _objectTransform = Object.Instantiate(objectTransform);
        }

        public ObjectInitialization(Transform objectTransform, Vector3 position)
        {
            _objectTransform = Object.Instantiate(objectTransform);
            _objectTransform.position = position;
        }

        public void Initialize()
        {

        }

        public Transform ObjectTransform => _objectTransform;
    }
}
