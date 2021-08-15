using UnityEngine;

namespace Arkanoid
{
    public interface IViewModelDirection : IViewModel
    {
        IDirection DirectionModel { get; }
        void DirectionChanged(Vector2 position, Vector2 targetPosition, float targetWidth);
    }
}