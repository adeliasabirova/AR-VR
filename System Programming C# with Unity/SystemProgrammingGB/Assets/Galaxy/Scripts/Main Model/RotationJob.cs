using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace Galaxy
{
    public struct RotationJob : IJobParallelForTransform
    {
        [ReadOnly]
        public NativeArray<Vector3> Velocities;
        [ReadOnly]
        public float DeltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            var rotation = Vector3.Scale(Velocities[index], Vector3.up * DeltaTime);
            transform.rotation = Quaternion.Euler(rotation + transform.rotation.eulerAngles);
        }
    }
}