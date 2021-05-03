using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids.Scenes
{
    /// <summary>
    /// объект сцены меню
    /// </summary>
    public class MenuScene : BaseScene
    {
        /// <summary>
        /// прорисовка меню игры
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Buffer.Graphics.DrawString("Меню игры", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 360, 100);
            Buffer.Graphics.DrawString("<Enter> - игра", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 400, 200);
            Buffer.Graphics.DrawString("<Esc> - выход", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.White, 400, 300);
            Buffer.Render();
        }

        /// <summary>
        /// обработка нажатия клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _logFile.Add("Game \'Asteroids\' is ended");
                string fileName = String.Format(@"{0}\asteroids_log_file.txt", Application.StartupPath);
                File.WriteAllLines(fileName, _logFile, Encoding.UTF8);
                _form.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                _logFile.Add("Game \'Asteroids\' is started.");
                SceneManager
                    .Get()
                    .Init<Game>(_form, _logFile)
                    .Draw();
            }
        }
    }
}
