using System.Collections.Generic;

namespace Galaxy
{
    internal sealed class Controllers : IInitialize, IExecute, ICleanUp
    {
        private readonly List<IInitialize> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanUp> _cleanUpControllers;

        public Controllers()
        {
            _initializeControllers = new List<IInitialize>();
            _executeControllers = new List<IExecute>();
            _cleanUpControllers = new List<ICleanUp>();
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
            if (controller is ICleanUp cleanupController)
            {
                _cleanUpControllers.Add(cleanupController);
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

        public void CleanUp()
        {
            for (var index = 0; index < _cleanUpControllers.Count; ++index)
            {
                _cleanUpControllers[index].CleanUp();
            }
        }
    }
}