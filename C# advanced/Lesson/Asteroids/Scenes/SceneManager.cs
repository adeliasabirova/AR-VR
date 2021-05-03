using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids.Scenes
{
    /// <summary>
    /// Инструмент управления сцен в игре.
    ///Менеджер сцен хранит в себе ссылку на текущую, созданную сцену, 
    ///при желании позволяет инициализировать новую сцену игры, корректно завершая работу, при этом, предыдущей сцены.
    /// </summary>
    public class SceneManager
    {
        private static SceneManager _sceneManager;
        private BaseScene _scene;

        public static SceneManager Get()
        {
            if (_sceneManager == null)
                _sceneManager = new SceneManager();
            return _sceneManager;
        }

        public IScene Init<T>(Form form, List<string> logFile) where T : BaseScene, new()
        {
            if (_scene != null)
                _scene.Dispose();

            _scene = new T();
            _scene.Init(form, logFile);
            return _scene;
        }

    }
}
