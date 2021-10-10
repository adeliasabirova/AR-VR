using Unity.Collections;
using Unity.Jobs;

namespace Homework2
{

    public struct AdvancedJob : IJob
    {
        public NativeArray<int> Array;

        public void Execute()
        {
            for (int i = 0; i < Array.Length; i++)
                if (Array[i] > 10)
                    Array[i] = 0;
        }
    }
}