namespace Project
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}