using UnityEngine;

namespace Asteroids
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer();
    }
}