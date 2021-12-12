using UnityEngine;

namespace Lesson2
{
    public class IMGuiExample1 : MonoBehaviour
    {
        private string textFieldValue = "Hello world";
        private string textAreaValue = "Hello world";
        private bool toggleBool = true;
        private int toolbarInt = 0;
        private string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };
        private int selectionGridInt = 0;
        private string[] selectionStrings = { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };
        private float hSliderValue = 0.0f;
        private float vSliderValue = 0.0f;
        private float hScrollbarValue;
        private float vScrollbarValue;
        private Vector2 scrollViewVector = Vector2.zero;
        private string innerText = "I am inside the ScrollView";
        private Rect windowRect = new Rect(Screen.width / 2 - 90, Screen.height / 2 - 100, 180, 175);
        private int selectedToolbar = 0;

        void OnGUI()
        {
            if (GUI.RepeatButton(new Rect(25, 25, 100, 30), "RepeatButton"))
                print("Button pressed right now");

            textFieldValue = GUI.TextField(new Rect(25, 60, 100, 30), textFieldValue);

            textAreaValue = GUI.TextArea(new Rect(25, 95, 100, 30), textAreaValue);

            toggleBool = GUI.Toggle(new Rect(25, 130, 100, 30), toggleBool, "Toggle");

            toolbarInt = GUI.Toolbar(new Rect(25, 165, 250, 30), toolbarInt, toolbarStrings);

            selectionGridInt = GUI.SelectionGrid(new Rect(25, 200, 300, 60), selectionGridInt, selectionStrings, 2);

            hSliderValue = GUI.HorizontalSlider(new Rect(25, 265, 100, 30), hSliderValue, 0.0f, 10.0f);

            vSliderValue = GUI.VerticalSlider(new Rect(25, 300, 100, 30), vSliderValue, 10.0f, 0.0f);

            hScrollbarValue = GUI.HorizontalScrollbar(new Rect(25, 335, 100, 30), hScrollbarValue, 1.0f, 0.0f, 10.0f);

            vScrollbarValue = GUI.VerticalScrollbar(new Rect(25, 370, 100, 30), vScrollbarValue, 1.0f, 10.0f, 0.0f);

            scrollViewVector = GUI.BeginScrollView(new Rect(25, 405, 100, 100), scrollViewVector, new Rect(0, 0, 400, 400));
            innerText = GUI.TextArea(new Rect(130, 405, 400, 400), innerText);
            GUI.EndScrollView();

            windowRect = GUI.Window(0, windowRect, WindowFunction, "Pause");

            selectedToolbar = GUI.Toolbar(new Rect(50, 510, 200, 30), selectedToolbar, toolbarStrings);
            if (GUI.changed)
            {
                Debug.Log("The toolbar was clicked");
                if (0 == selectedToolbar)
                {
                    Debug.Log("First button was clicked");
                }
                else
                {
                    Debug.Log("Second button was clicked");
                }
            }
        }

        private void WindowFunction(int windowID)
        {
            if (GUI.Button(new Rect(windowRect.width / 2 - 80, 30, 160, 30), "Continue"))
                print("Continue");
            if (GUI.Button(new Rect(windowRect.width / 2 - 80, 65, 160, 30), "Restart"))
                print("Restart");
            if (GUI.Button(new Rect(windowRect.width / 2 - 80, 100, 160, 30), "Settings"))
                print("Settings");
            if (GUI.Button(new Rect(windowRect.width / 2 - 80, 135, 160, 30), "Exit"))
                print("Exit");
        }
    }
}