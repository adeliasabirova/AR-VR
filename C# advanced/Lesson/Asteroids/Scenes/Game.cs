using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Asteroids.Properties;
using System.Diagnostics;

namespace Asteroids.Scenes
{
    public class Game : BaseScene
    {
        private List<Asteroid> asteroids;
        private List<Star> stars;
        private BaseObject comet;
        private Random random = new Random();
        private List<Bullet> bullets = new List<Bullet>();
        private Ship ship;
        private FirstAid firstAid;
        private Timer timer;
        private int level = 0;
        
        static Game() { }

        /// <summary>
        /// Инициализация программы + обработка исключения создания окна
        /// по заданию не больше 1000, я поставила не более 1500, и если больше, то ставить размер окна (1200, 600)
        /// </summary>
        /// <param name="form">передачи формы, на которой будет отрисовываться программа</param>
        public override void Init(Form form, List<string> logFile)
        {
            base.Init(form, logFile);
            Load();

            timer = new Timer { Interval = 60 };
            timer.Start();
            timer.Tick += OnTick;
            Ship.MessageDie += OnDie;
            Ship.MessageWin += OnWin;
            Ship.MessageCure += OnCure;
            Ship.MessageDamage += OnDamage;
            Asteroid.MessageGoal += OnGoal;
        }

        /// <summary>
        /// обработка кнопок клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey && bullets.Count < 5)
            {
                bullets.Add(new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 21), new Point(5, 0), new Size(54, 9)));
            }
            if (e.KeyCode == Keys.Up)
            {
                ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                ship.Down();
            }
            if (e.KeyCode == Keys.Back)
            {
                SceneManager
                    .Get()
                    .Init<MenuScene>(_form, _logFile)
                    .Draw();
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Отрисовка заднего фона и объектов сцены
        /// </summary>
        public override void Draw()
        {
            base.Draw();

            foreach (var asteroid in asteroids)
                    asteroid.Draw();

            foreach (var star in stars)
                star.Draw();

            comet.Draw();

            foreach (var bullet in bullets)
                bullet.Draw();

            if (ship != null)
            {
                ship.Draw();
                Buffer.Graphics.DrawString($"Energy: {ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString($"Score: {ship.Score}", SystemFonts.DefaultFont, Brushes.Yellow, 100, 0);
            }

            if (firstAid != null)
                firstAid.Draw();

            Buffer.Render();
        }

        /// <summary>
        /// Обновление движения объектов сцены
        /// </summary>
        public void Update()
        {
            foreach (var bullet in bullets)
                bullet.Update();

            for(int i = 0; i<bullets.Count; i++)
            {
                if( bullets[i].Rect.X > Game.Width)
                {
                    bullets.RemoveAt(i);
                    i--;

                }
            }

            for(int i = 0; i<asteroids.Count; i++)
            {
                asteroids[i].Update();
                bool fAsteroid = true;

                for (int j = 0; j < bullets.Count; j++)
                {
                    if (bullets[j].Collision(asteroids[i]) && fAsteroid)
                    {
                        ship.ScoreEvaluation(asteroids[i].Rect.Width + level*j);
                        asteroids[i].Die();
                        asteroids.RemoveAt(i);
                        fAsteroid = false;
                        bullets.RemoveAt(j);
                        j--;
                        break;
                    }
                }

                if (!fAsteroid) i--;

            }


            for(int i = 0; i< asteroids.Count; i++)
            {
                if (ship != null && ship.Collision(asteroids[i]))
                {
                    ship.EnergyLow(random.Next(1, 10));
                    System.Media.SystemSounds.Hand.Play();

                    if (ship.Energy <= 0)
                        ship.Die();
                }

            }



            if (level == 2 && asteroids.Count == 0) ship.Win();
            else if (level < 2 && asteroids.Count == 0) 
            { 
                level++;
                LoadAsteroids();
                _logFile.Add($"New level!");
            }


            foreach (var star in stars)
                star.Update();

            comet.Update();

            if (firstAid == null)
            {
                //если аптечка была сбита, то создается новая
                int i = random.Next(0, 2);
                if (i == 1)
                    firstAid = new FirstAid(new Point(random.Next(0, Width)), new Point(0, 5), new Size(25, 24));
            }
            else 
            { 
                firstAid.Update();
                for(int i=0; i< bullets.Count; i++)
                {
                    if (firstAid!= null && bullets[i].Collision(firstAid))
                    {
                        ship.EnergyUp(firstAid.Energy);
                        firstAid = null;
                        bullets.RemoveAt(i);
                        i--;
                    }
                }

                if(firstAid != null && ship != null && ship.Collision(firstAid))
                {
                    ship.EnergyUp(firstAid.Energy);
                    firstAid = null;
                }
            }
        }

        //загрузка астероидов
        private void LoadAsteroids()
        {
            asteroids = new List<Asteroid>();
            for (int i = 0; i < 10 + level; i++)
            {
                var size = random.Next(10, 40);
                try
                {
                    asteroids.Add(new Asteroid(new Point(600, i * 20), new Point(-i - 1, -i - 1), new Size(size, size)));
                }
                catch (GameObjectException e)
                {
                    Debug.WriteLine(e.Message + " Установлены нулевые значения.");
                    asteroids.Add(new Asteroid(new Point(0, 0 + i), new Point(-20, -20), new Size(Math.Abs(size), Math.Abs(size))));
                }
            }
        }

        /// <summary>
        /// Загрузка объектов сцены при инициализации программы + обработка исключения на создание звезд и астероидов
        /// </summary>
        public void Load()
        {
            ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(45, 50));
            //Ship.MessageDie += OnDie;
            //Ship.MessageWin += OnWin;
            //Ship.MessageCure += OnCure;
            //Ship.MessageDamage += OnDamage;
            //Ship.MessageGoal += OnGoal;

            firstAid = new FirstAid(new Point(random.Next(0, Width)), new Point(0, 5), new Size(25, 24));

            LoadAsteroids();

            stars = new List<Star>();
            int starsCount = 15;
            for (int i = 0; i < starsCount; i++)
            {
                var size = random.Next(5, 15);
                try
                {
                    stars.Add(new Star(new Point(200, i * 40), new Point(-i - 1, -i - 1), new Size(size, size)));
                }
                catch (GameObjectException e)
                {
                    Debug.WriteLine(e.Message + " Установлены нулевые значения.");
                    stars.Add(new Star(new Point(0, 0), new Point(-50, -50), new Size(Math.Abs(size), Math.Abs(size))));
                }
            }

            comet = new Comet(new Point(0, 0), new Point(20, 20), new Size(15, 15));
        }
        /// <summary>
        /// обработка события выйгрыша
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWin(object sender, EventArgs e)
        {
            timer.Stop();
            Ship senderShip = sender as Ship;
            _logFile.Add($"Game \'Asteroids\' is won with score: {senderShip.Score} and energy: {senderShip.Energy}");
            Buffer.Graphics.DrawString("Win", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Green, 500, 200);
            Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 0, 30);
            Buffer.Render();
        }

        /// <summary>
        /// обработка события проигрыша
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDie(object sender, EventArgs e)
        {
            timer.Stop();
            Ship senderShip = sender as Ship;
            _logFile.Add($"Game \'Asteroids\' is lost with score: {senderShip.Score}");
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.Red, 400, 200);
            Buffer.Graphics.DrawString("<Backspace> - в меню", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 0, 30);
            Buffer.Render();
        }

        /// <summary>
        /// обработка события поподания по астероиду стрелой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGoal(object sender, EventArgs e)
        {
            Asteroid senderAsteroid = sender as Asteroid;
            _logFile.Add($"Asteroid is shot down at position ({senderAsteroid.Rect.X}, {senderAsteroid.Rect.Y}), asteroid's size is ({senderAsteroid.Rect.Width}, {senderAsteroid.Rect.Height}).");
        }

       /// <summary>
       /// обработка события поподания по кораблю астероидом
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void OnDamage(object sender, EventArgs e)
        {
            _logFile.Add("Ship has been damaged.");
        }

        /// <summary>
        /// обработка события попадания по аптечке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCure(object sender, EventArgs e)
        {
            _logFile.Add("Ship has been cured.");
        }

        public override void Dispose()
        {
            base.Dispose();
            timer.Stop();
        }
    }
}
