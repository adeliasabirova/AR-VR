using UnityEngine;

namespace Lesson2
{
    public class Example1: MonoBehaviour
    {
        private string message;

        private void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 200, 140), "Main Menu");
            if (GUI.Button(new Rect(20, 40, 180, 30), "Open"))
                message = "Open";
            if (GUI.Button(new Rect(20, 75, 180, 30), "Save"))
                message = "Save";
            if (GUI.Button(new Rect(20, 110, 180, 30), "Load"))
                message = "Load";
            GUI.Label(new Rect(220, 10, 100, 30), message);

        }
    }
}