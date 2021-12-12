namespace Game
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}