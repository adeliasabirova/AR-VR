using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    internal sealed class Controllers : IInitialize, IExecute, ILateExecute, ICleanUp, IGUI, IAnimatorMove, IAnimatorIK
    {
        private readonly List<IInitialize> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateExecuteControllers;
        private readonly List<ICleanUp> _cleanUpControllers;
        private readonly List<IGUI> _guiControllers;
        private readonly List<IAnimatorMove> _animatorControllers;
        private readonly List<IAnimatorIK> _animatorIKControllers;

        public Controllers()
        {
            _initializeControllers = new List<IInitialize>();
            _executeControllers = new List<IExecute>();
            _lateExecuteControllers = new List<ILateExecute>();
            _cleanUpControllers = new List<ICleanUp>();
            _guiControllers = new List<IGUI>();
            _animatorControllers = new List<IAnimatorMove>();
            _animatorIKControllers = new List<IAnimatorIK>();
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
            if (controller is IAnimatorMove animatorController)
            {
                _animatorControllers.Add(animatorController);
            }
            if (controller is IAnimatorIK animatorIKControllers)
            {
                _animatorIKControllers.Add(animatorIKControllers);
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

        public void AnimatorMove(float deltaTime)
        {
            for (var index = 0; index < _animatorControllers.Count; ++index)
            {
                _animatorControllers[index].AnimatorMove(deltaTime);
            }
        }

        public void AnimatorIK(int layerIndex)
        {
            for (var index = 0; index < _animatorIKControllers.Count; ++index)
            {
                _animatorIKControllers[index].AnimatorIK(layerIndex);
            }
        }
    }
}
