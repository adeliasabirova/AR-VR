using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Controllers : IInitialize, IExecute, ILateExecute, ICleanup
    {
        private readonly List<IInitialize> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateExecuteControllers;
        private readonly List<ICleanup> _cleanupControllers;

        public Controllers()
        {
            _initializeControllers = new List<IInitialize>();
            _executeControllers = new List<IExecute>();
            _lateExecuteControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        internal Controllers Add(IController controller)
        {
            if(controller is IInitialize initializeController)
            {
                _initializeControllers.Add(initializeController);
            }
            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }
            if (controller is ILateExecute lateExecuteController)
            {
                _lateExecuteControllers.Add(lateExecuteController);
            }
            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
            return this;
        }

        public void Initialize()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialize();
            }
        }

        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            for (var index = 0; index < _lateExecuteControllers.Count; ++index)
            {
                _lateExecuteControllers[index].LateExecute(deltaTime);
            }

        }

        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }
    }
}
