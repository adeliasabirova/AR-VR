using System;
using UnityEngine;

namespace Project
{
    internal sealed class Player : MonoBehaviour, IPlayer
    {
        public event Action<float> OnAnimatorMoveChange;
        public event Action<int> OnAnimatorIKChange;

        private void OnAnimatorIK(int layerIndex)
        {
            OnAnimatorIKChange?.Invoke(layerIndex);
        }

        private void OnAnimatorMove()
        {
            OnAnimatorMoveChange?.Invoke(Time.deltaTime);
        }
    }
}