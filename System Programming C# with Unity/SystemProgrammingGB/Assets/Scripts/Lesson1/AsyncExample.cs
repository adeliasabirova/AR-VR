using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Lesson1
{
    public class AsyncExample : MonoBehaviour
    {
        private void Start()
        {
            //PrintAsync();
            //PrintAsync("message", 50);
            //UnitTasksAsync();
            //WhenAnyAsync();
            FactorialStart();
        }

        async void PrintAsync()
        {
            Debug.Log($"Message was printed instantly.");
            await Task.Delay(1000);
            Debug.Log($"Message was printed over 1 second.");
        }

        async void PrintAsync(string message, int frames)
        {
            while (frames > 0)
            {
                frames--;
                Debug.Log(message);
                await Task.Yield();
            }
        }

        async void UnitTasksAsync()
        {
            Task task1 = Task.Run(() => Unit1Async());
            Task task2 = Task.Run(() => Unit2Async());
            await Task.WhenAll(task1, task2);
            Debug.Log("All units have finished their tasks.");
        }

        async void Unit1Async()
        {
            Debug.Log("Unit1 starts chopping wood.");
            await Task.Delay(3000);
            Debug.Log("Unit1 finishes chopping wood.");
        }

        async void Unit2Async()
        {
            Debug.Log("Unit2 starts patrolling.");
            await Task.Delay(5000);
            Debug.Log("Unit2 finishes patrolling.");
        }

        async void WhenAnyAsync()
        {
            Task<int> task1 = WaitRandomTime();
            Task<int> task2 = WaitRandomTime();
            var taskResult = await Task.WhenAny(task1, task2);
            Debug.Log(taskResult.Result);
        }

        async Task<int> WaitRandomTime()
        {
            int rnd = Random.Range(100, 1000);
            await Task.Delay(rnd);
            return rnd;
        }

        void FactorialStart()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = cancelTokenSource.Token;

            Task task = new Task(() => FactorialAsync(cancelToken, 5));
            task.Start();

            cancelTokenSource.Cancel();
            cancelTokenSource.Dispose();
        }

        async Task<long> FactorialAsync(CancellationToken cancelToken, int x)
        {
            int result = 1;
            for (int i = 1; i < x; i++)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    Debug.Log("Операция прервана токеном.");
                    return result;
                }

                result *= i;
                await Task.Yield();
            }

            return result;
        }

    }
}
