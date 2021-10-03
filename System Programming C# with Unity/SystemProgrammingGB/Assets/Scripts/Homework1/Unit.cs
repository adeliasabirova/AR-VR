using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Homework1
{
    public class Unit : MonoBehaviour
    {
        private int _health = 0;
        public int Health => _health;

        public void ReceiveHealing()
        {
            StopAllCoroutines();
            StartCoroutine(HealUnit());
        }

        IEnumerator HealUnit()
        {
            float timer = 0.0f;
            while(_health < 100 && timer <3.0f)
            {
                yield return new WaitForSeconds(0.5f);
                _health += 5;
                timer += 0.5f;
            }
        }

        private void Start()
        {
            UnitTasksAsync();
        }

        async void UnitTasksAsync()
        {
            using (CancellationTokenSource cancellationTokenSource = new CancellationTokenSource())
            {
                CancellationToken cancellationToken = cancellationTokenSource.Token;

                Task<bool> task1 = Task.Run(() => Task1Async(cancellationToken));
                Task<bool> task2 = Task.Run(() => Task2Async(cancellationToken));
                Task<bool> taskResult = await Task.WhenAny(task1, task2);
                bool result = (taskResult == task1 && taskResult.Result == true);


                cancellationTokenSource.Cancel();
                Debug.Log("Result is " + result.ToString());
                cancellationTokenSource.Dispose();
            }
        }

        async Task<bool> Task1Async(CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
            Debug.Log("Task1 finishes.");

            if (cancellationToken.IsCancellationRequested)
            {
                Debug.Log("Token is requested for task1");
                return false;
            }

            return true;
        }

        async Task<bool> Task2Async(CancellationToken cancellationToken)
        {
            int frames = 60;

            while (frames > 0)
            {
                frames--;
                await Task.Yield();
            }
            Debug.Log("Task2 finishes.");

            if (cancellationToken.IsCancellationRequested)
            {
                Debug.Log("Token is requested for task2");
                return false;
            }
            return false;
        }
    }
}