using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Lesson1
{
    public class TryPopUp : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefabPopUp;

        private void Start()
        {
            TryBuyItem();
        }

        public void TryBuyItem()
        {
            GameObject newPopup = Instantiate(_prefabPopUp);
            SomePopUp popupScript = newPopup.GetComponent<SomePopUp>();
            popupScript.OnClose += CompletePurhase;

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            popupScript.ActivatePopup(ct);
        }

        void CompletePurhase(bool completed)
        {
            if (completed) Debug.Log("Покупка совершена!");
            else Debug.Log("Покупка отменена!");
        }
    }
}
