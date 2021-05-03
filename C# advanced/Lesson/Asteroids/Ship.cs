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
    public class Ship : BaseObject
    {
        private int energy = 100;
        private int score = 0;
        public static event EventHandler MessageDie, MessageWin, MessageDamage, MessageCure;
        public int Energy => energy;
        public int Score => score;
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        /// <summary>
        /// очки за сбитые астероиды
        /// </summary>
        /// <param name="n"></param>
        public void ScoreEvaluation(int n) 
        {
            score += n;
        }
        /// <summary>
        /// убавление энергии за нанесенный урон
        /// </summary>
        /// <param name="n"></param>
        public void EnergyLow(int n)
        {
            energy -= n;
            if (MessageDamage != null)
                MessageDamage.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// повышение энерги за аптечки
        /// </summary>
        /// <param name="n"></param>
        public void EnergyUp(int n)
        {
            energy += n;
            if(MessageCure != null)
                MessageCure.Invoke(this, new EventArgs());
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Resources.ship, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Die()
        {
            if (MessageDie != null)
                MessageDie.Invoke(this, new EventArgs());
        }

        public void Win()
        {
            if (MessageWin != null)
                MessageWin.Invoke(this, new EventArgs());
        }

        public override void Update() { }
    }
}
