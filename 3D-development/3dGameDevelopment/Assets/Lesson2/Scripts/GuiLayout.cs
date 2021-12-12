using UnityEngine;

namespace Lesson2
{

    public class GuiLayout : MonoBehaviour
    {
        private float sliderValue;

        private void OnGUI()
        {
            GUILayout.Button("I am not inside an Area");
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
            GUILayout.Button("I am inside an Area");
            GUILayout.Button("Overridden Button", GUILayout.Width(120));
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(10, 100, 200, 100));
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            if (GUILayout.RepeatButton("Min"))
                sliderValue = 0.0f;
            if (GUILayout.RepeatButton("Max"))
                sliderValue = 10.0f;
            GUILayout.EndVertical();
            GUILayout.BeginVertical();
            GUILayout.Label("Some slider: ");
            sliderValue = GUILayout.HorizontalSlider(sliderValue, 0.0f, 10.0f);
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }
}