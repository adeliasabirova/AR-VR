namespace Asteroids
{
    public interface IUnit
    {
        float Speed { get; }
        float Acceleration { get; }
        Player GetPlayer();
    }
}
