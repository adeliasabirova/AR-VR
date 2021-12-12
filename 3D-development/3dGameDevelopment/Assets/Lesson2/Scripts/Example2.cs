using UnityEngine;

namespace Lesson2
{
    public class Example2 : MonoBehaviour
    {
        public Texture2D icon;
        void OnGUI()
        {
            GUI.Box(new Rect(0, 0, 100, 50), "Top-left");
            GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Top-right");
            GUI.Box(new Rect(0, Screen.height - 50, 100, 50), "Bottom-left");
            GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-right");

            GUI.BeginGroup(new Rect(500, 500, 100, 100));
            GUI.Label(new Rect(0, 0, 50, 20), "Hello");
            GUI.Label(new Rect(0, 25, 50, 20), "World!");
            GUI.EndGroup();

            GUI.Box(new Rect(100, 10, 100, 100), new GUIContent("Text", icon));
        }
    }
}