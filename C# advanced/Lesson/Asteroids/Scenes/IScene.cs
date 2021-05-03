using System.Collections.Generic;
using System.Windows.Forms;

namespace Asteroids.Scenes
{
    /// <summary>
    /// интерфейс сцены
    /// </summary>
    public interface IScene
    {
        void Init(Form form, List<string> logFile);
        void Draw();
    }
}