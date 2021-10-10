using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace Homework2
{
    public struct AdvancedJobForTransform : IJobParallelForTransform
    {
        [ReadOnly]
        public float DeltaTime;
        [ReadOnly]
        public float Speed;

        public void Execute(int index, TransformAccess transform)
        {
            var rotation = Speed * DeltaTime * Vector3.up;
            transform.rotation = Quaternion.Euler(rotation + transform.rotation.eulerAngles);
        }
    }
}