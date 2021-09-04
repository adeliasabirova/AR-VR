namespace Asteroids
{
    public interface IDealingCreate
    {
        void Visit(IEnemy enemy, InfoCreation info);
        void Visit(IBullet bullet, InfoCreation info);
    }
}