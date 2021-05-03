using Asteroids.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Определение пользовательского исключения
    /// </summary>
    public class GameObjectException : Exception
    {
        public GameObjectException(string message) : base(message) { }
    }

    /// <summary>
    /// Базовый класс объекта
    /// </summary>
    public abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X > Game.Width || pos.Y > Game.Height) throw new GameObjectException($"Создается объект с неправильными характеристиками позиции.");
            else Pos = pos;
            if (dir.X >= 50 || dir.Y >= 50) throw new GameObjectException($"Создается объект с неправильными характеристиками скорости.");
            else Dir = dir;
            if (size.Width < 0 || size.Height < 0) throw new GameObjectException($"Создается объект с неправильными характеристиками размера.");
            else Size = size;
        }

        /// <summary>
        /// метод изменения позиций объекта, реализовано для обратботки коллизий между объектами
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        public virtual void SetObject(Point pos, Size size)
        {
            Pos = pos;
            Size = size;
        }

        /// <summary>
        /// получение и обработка пересечений
        /// </summary>
        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(Rect);
        }

        public abstract void Draw();
        public abstract void Update();
    }
}
