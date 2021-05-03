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
    public class Asteroid : BaseObject
    {
        public static event EventHandler MessageGoal;
        /// <summary>
        /// конструктор объекта астероида
        /// </summary>
        /// <param name="pos">позиция</param>
        /// <param name="dir">направление</param>
        /// <param name="size">размер</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        /// <summary>
        /// вызов события сбитого астероида
        /// </summary>
        public void Die()
        {
            if (MessageGoal != null)
                MessageGoal.Invoke(this, new EventArgs());
        }
        public override void SetObject(Point pos, Size size)
        {
            base.SetObject(pos, size);
        }
        /// <summary>
        /// Отрисовка астероида 
        /// </summary>
        /// 
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big1, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        /// <summary>
        /// обновление движения астероида на сцене
        /// </summary>
        public override void Update()
        {
            Pos.X += 3*Dir.X;
            Pos.Y += (int)1.5*Dir.Y;

            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X >= Game.Width) Dir.X = -Dir.X;

            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y >= Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
