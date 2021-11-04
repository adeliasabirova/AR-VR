using UnityEngine;

namespace Lesson2
{
    public class IMGui : MonoBehaviour
    {
        private float mySlider = 1.0f;
        public Color myColor;
        void OnGUI()
        {
            mySlider = LabelSlider1(new Rect(10, 10, 200, 20), mySlider, 5.0f, "Slider name");

            myColor = RGBSlider(new Rect(10, 50, 200, 20), myColor);
        }

        Color RGBSlider(Rect screenRect, Color rgb)
        {
            rgb.r = LabelSlider2(screenRect, rgb.r, 1.0f, "Red");
            screenRect.y += 20;
            rgb.g = LabelSlider2(screenRect, rgb.g, 1.0f, "Green");
            screenRect.y += 20;
            rgb.b = LabelSlider2(screenRect, rgb.b, 1.0f, "Blue");
            return rgb;
        }

        float LabelSlider1(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
        {
            Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
            GUI.Label(labelRect, labelText);
            Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
            sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue);
            return sliderValue;
        }

        float LabelSlider2(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
        {
            GUI.Label(screenRect, labelText);
            screenRect.x += screenRect.width;
            sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f, sliderMaxValue);
            return sliderValue;
        }
    }
}