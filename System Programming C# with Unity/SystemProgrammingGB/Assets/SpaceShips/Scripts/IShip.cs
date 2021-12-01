using System;

namespace SpaceShips
{
    public interface IShip
    {
        event Action OnCollisionEnterChange;
    }
}