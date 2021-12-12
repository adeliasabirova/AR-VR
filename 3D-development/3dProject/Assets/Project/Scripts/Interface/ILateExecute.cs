namespace Game
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}