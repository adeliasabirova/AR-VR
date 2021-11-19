using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    internal sealed class Controllers : IInitialize, IExecute, ILateExecute, ICleanUp, IGUI
    {
        private readonly List<IInitialize> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateExecuteControllers;
        private readonly List<ICleanUp> _cleanUpControllers;
        private readonly List<IGUI> _guiControllers;

        public Controllers()
        {
            _initializeControllers = new List<IInitialize>();
            _executeControllers = new List<IExecute>();
            _lateExecuteControllers = new List<ILateExecute>();
            _cleanUpControllers = new List<ICleanUp>();
            _guiControllers = new List<IGUI>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialize initializeController)
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
            if (controller is ICleanUp cleanupController)
            {
                _cleanUpControllers.Add(cleanupController);
            }
            if(controller is IGUI guiController)
            {
                _guiControllers.Add(guiController);
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

        public void CleanUp()
        {
            for (var index = 0; index < _cleanUpControllers.Count; ++index)
            {
                _cleanUpControllers[index].CleanUp();
            }
        }

        public void Gui()
        {
            for (var index = 0; index < _guiControllers.Count; ++index)
            {
                _guiControllers[index].Gui();
            }
        }

    }
}
