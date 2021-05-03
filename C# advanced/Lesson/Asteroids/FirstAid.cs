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
    /// <summary>
    /// класс аптечки
    /// </summary>
    class FirstAid : BaseObject
    {
        private Random random = new Random();

        /// <summary>
        /// рандомно генерируется количество энергии в аптечке
        /// </summary>
        public int Energy => random.Next(10, 21);
        public FirstAid(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        /// <summary>
        /// прорисовка аптечки
        /// у меня не было картинки аптечки, поэтому у меня звездочка вместо аптечки падает сверху
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Resources.star1, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// если аптечка не была сбита и она ниже окна игры, то переопределяется ее позиция
        /// </summary>
        private void NewPosition()
        {
            var new_x = random.Next(0, Game.Width);
            Pos = new Point(new_x, 0);
        }

        public override void Update()
        {
            Pos.Y += 5;

            if (Pos.Y > Game.Height)
                NewPosition();
        }
    }
}
