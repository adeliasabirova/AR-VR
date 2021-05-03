using Asteroids.Properties;
using Asteroids.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Comet : BaseObject
    {
        Random random = new Random();

        /// <summary>
        /// конструктор объекта кометы на сцене
        /// </summary>
        /// <param name="pos">позиция</param>
        /// <param name="dir">направление</param>
        /// <param name="size">размер</param>
        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        /// <summary>
        /// отрисовка кометы
        /// </summary>

        public override void SetObject(Point pos, Size size)
        {
            base.SetObject(pos, size);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Resources.star2, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Определение новой позиции кометы, направления и размер
        /// </summary>
        private void NewPosition()
        {
            var new_x = random.Next(0, Game.Width);
            int i = (int)random.Next(0, 2);
            var new_dir = random.Next(20, 60);
            var new_size = random.Next(15, 30);
            Pos = new Point(new_x, 0);
            if (i == 0)
                Dir = new Point(new_dir, new_dir);
            else
                Dir = new Point(-1 * new_dir, new_dir);
            Size = new Size(new_size, new_size);

        }

        /// <summary>
        /// движение кометы на сцене
        /// </summary>
        private void Move()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
        }

        /// <summary>
        /// обновление движения кометы на сцене
        /// если комета заходит за нижнюю границу окна, создается новая позиция кометы сверху окна
        /// </summary>
        public override void Update()
        {
            if (Dir.X > 0 && Dir.Y > 0)
            {
                if (Pos.X < Game.Width || Pos.Y < Game.Height) Move();
                else NewPosition();
            }
            else if (Dir.X < 0 && Dir.Y > 0)
            {
                if (Pos.X > 0 || Pos.Y < Game.Height) Move();
                else NewPosition();
            }

        }
    }
}
