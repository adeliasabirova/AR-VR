using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Homework2
{
    public class Solution1 : MonoBehaviour
    {
        private NativeArray<int> _array;
        private JobHandle _handle;

        private void Start()
        {
            Task1();
        }

        private void Task1()
        {
            _array = ArrayGeneration();
            AdvancedJob job = new AdvancedJob();
            job.Array = _array;
            _handle = job.Schedule();
            _handle.Complete();
            StartCoroutine(JobCoroutine());
        }

        private NativeArray<int> ArrayGeneration()
        {
            var array = new NativeArray<int>(15, Allocator.TempJob);
            for (int i = 0; i < 15; i++)
                array[i] = Random.Range(1, 20);
            Debug.Log("Array before Jobs System");
            foreach (var item in array)
                Debug.Log(item);
            return array;
        }

        IEnumerator JobCoroutine()
        {
            while (_handle.IsCompleted == false)
                yield return new WaitForEndOfFrame();
            Debug.Log("Array after Jobs System");
            foreach (var item in _array)
                Debug.Log(item);

            _array.Dispose();
        }
    }
}
