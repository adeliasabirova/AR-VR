using System.Collections;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Homework2
{
    public class Solution2 : MonoBehaviour
    {
        private NativeArray<Vector3> _positions;
        private NativeArray<Vector3> _velocities;
        private NativeArray<Vector3> _finalPositions;
        private JobHandle _handle;

        private void Start()
        {
            Task2();
        }

        private NativeArray<Vector3> ArrayGeneration()
        {
            var array = new NativeArray<Vector3>(15, Allocator.TempJob);
            for (int i = 0; i < 15; i++)
                array[i] = Random.insideUnitSphere * Random.Range(0, 20);

            return array;
        }

        private void Task2()
        {
            _positions = ArrayGeneration();
            _velocities = ArrayGeneration();
            _finalPositions = new NativeArray<Vector3>(15, Allocator.TempJob);
            AdvancedJobParallelFor job = new AdvancedJobParallelFor()
            {
                Positions = _positions,
                Velocities = _velocities,
                FinalPositions = _finalPositions
            };
            _handle = job.Schedule(15, 5);
            _handle.Complete();
            StartCoroutine(JobCoroutine());
        }

        IEnumerator JobCoroutine()
        {
            while (_handle.IsCompleted == false)
                yield return new WaitForEndOfFrame();

            foreach (var item in _finalPositions)
                Debug.Log(item);

            _positions.Dispose();
            _velocities.Dispose();
            _finalPositions.Dispose();
        }

    }
}
