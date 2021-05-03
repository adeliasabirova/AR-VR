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
    /// класс объекта пуля
    /// </summary>
    public class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void SetObject(Point pos, Size size)
        {
            base.SetObject(pos, size);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Resources.laserRed011, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X += 10;
        }
    }
}
