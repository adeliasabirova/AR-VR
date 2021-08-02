namespace Asteroids
{
    public interface IPlayerFactory: IBarrelPosition
    {
        IPlayer CreatePlayer();
    }
}