using System;
using UnityEngine;

namespace SpaceShips
{
    public class Ship : MonoBehaviour, IShip
    {
        public event Action OnCollisionEnterChange;

        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterChange?.Invoke();
        }
    }
}