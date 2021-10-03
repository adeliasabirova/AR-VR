using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Lesson1
{
    public class AsyncExample : MonoBehaviour
    {
        private void Start()
        {
            PrintAsync();
        }

        async void PrintAsync()
        {
            Debug.Log($"Message was printed instantly.");
            await Task.Delay(1000);
            Debug.Log($"Message was printed over 1 second.");
        }
    }
}
