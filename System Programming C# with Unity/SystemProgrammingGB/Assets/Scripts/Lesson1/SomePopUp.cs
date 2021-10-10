using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Lesson1
{
    public delegate void CloseHandler(bool accepted);
    public class SomePopUp : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonAccept;
        [SerializeField]
        private Button _buttonCancel;

        public CloseHandler OnClose;


        async Task<bool> PressButtonAsync(CancellationToken ct, Button button)
        {
            bool isPressed = false;
            button.onClick.AddListener(() => isPressed = true);
            while (isPressed == false)
            {
                if (ct.IsCancellationRequested)
                {
                    return false;
                }
                await Task.Yield();
            }
            return true;
        }

        public async void ActivatePopup(CancellationToken ct)
        {
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct))
            {
                CancellationToken linkedCt = linkedCts.Token;
                Task<bool> task1 = PressButtonAsync(linkedCt, _buttonAccept);
                Task<bool> task2 = PressButtonAsync(linkedCt, _buttonCancel);
                Task<bool> finishedTask = await Task.WhenAny(task1, task2);
                bool result = (finishedTask == task1 && finishedTask.Result == true);
                Debug.Log($"Result = {result}");
                linkedCts.Cancel();
                OnClose?.Invoke(result);
            }
        }
    }
}