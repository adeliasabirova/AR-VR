using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class UIInitialization : IInitialize, IExecute, ICleanup
    {
        protected readonly BaseUI _baseUI;
        protected Dictionary<string, string> _dict;
        protected UIInitialization(BaseUI baseUI)
        {
            _baseUI = baseUI;
            _dict = new Dictionary<string, string>();
        }
        public virtual void Cleanup()
        {
            _baseUI.Cancel();
        }
        public virtual void Execute(float deltaTime)
        {
        }
        public virtual void Initialize()
        {
            _baseUI.Cancel();
        }
    }
}
