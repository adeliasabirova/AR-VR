using Asteroids.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids.Scenes
{
    /// <summary>
    /// объект основной сцены
    /// </summary>
    public abstract class BaseScene : IScene, IDisposable
    {
        protected BufferedGraphicsContext _context;
        protected Form _form;
        public static BufferedGraphics Buffer;
        protected List<string> _logFile;

        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// инициализация объекта
        /// </summary>
        /// <param name="form">виндовс форма</param>
        /// <param name="logFile">лог-файл</param>
        public virtual void Init(Form form, List<string> logFile)
        {
            _form = form;
            _logFile = logFile;
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = _form.CreateGraphics();
            try
            {
                if (_form.ClientSize.Width <= 1500 && _form.ClientSize.Height <= 1500 && _form.ClientSize.Width > 0 && _form.ClientSize.Height > 0)
                {
                    Width = _form.ClientSize.Width;
                    Height = _form.ClientSize.Height;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Debug.WriteLine($"Argument Out Of Range. Нулевые значения установленны (1200, 600).");
                Width = 1200;
                Height = 600;
                _form.Size = new Size(Width, Height);
            }

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            _form.KeyDown += SceneKeyDown;
        }

        //public virtual void Init(Form form, List<string> logFile)
        //{
        //    _form = form;
        //    _logFile = logFile;
        //    Graphics g;
        //    _context = BufferedGraphicsManager.Current;
        //    g = _form.CreateGraphics();
        //    Width = _form.ClientSize.Width;
        //    Height = _form.ClientSize.Height;
        //    Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

        //    _form.KeyDown += SceneKeyDown;
        //}

        public virtual void SceneKeyDown(object sender, KeyEventArgs e) { }

        /// <summary>
        /// прорисовка заднего фона
        /// </summary>
        public virtual void Draw() 
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, 1200, 600));
            Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(800, 100, 100, 100));
        }

        public virtual void Dispose()
        {
            Buffer = null;
            _context = null;
            _form.KeyDown -= SceneKeyDown;
        }
    }
}
