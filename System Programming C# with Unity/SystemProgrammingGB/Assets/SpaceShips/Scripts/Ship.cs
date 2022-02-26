using System;
using UnityEngine;
using UnityEngine.Networking;

namespace SpaceShips
{
    public class Ship : MonoBehaviour, IShip
    {
        public event Action OnCollisionEnterChange;

        [ClientCallback]
        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterChange?.Invoke();
        }
    }
}