using Asteroids.Properties;
using Asteroids.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Star : BaseObject
    {
        /// <summary>
        /// конструктор объекта звезды
        /// </summary>
        /// <param name="pos">позиция</param>
        /// <param name="dir">направление</param>
        /// <param name="size">размер</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        /// <summary>
        /// отрисовка звезды картинкой
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Resources.star3, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// обновление движения звезды на сцене
        /// </summary>
        public override void Update()
        {
            Pos.X += 3 * Dir.X;
            Pos.Y += 10*(int)Math.Sin(Math.PI*Dir.Y);

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X >= Game.Width) Dir.X = -Dir.X;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y >= Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
