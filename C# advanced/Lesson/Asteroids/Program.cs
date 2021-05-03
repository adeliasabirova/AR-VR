using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Asteroids.Scenes;

namespace Asteroids
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var form = new Form()
            {
                Size = new Size(1600, 600),
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Asteroids"
            };
            form.Show();

            //создание лог-файла
            List<string> logFile = new List<string>();

            SceneManager
                .Get()
                .Init<MenuScene>(form, logFile)
                .Draw();

            Application.Run(form);
        }
    }
}
