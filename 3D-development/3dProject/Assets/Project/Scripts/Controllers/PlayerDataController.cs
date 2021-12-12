using UnityEngine;
namespace Game
{
    internal sealed class PlayerDataController : IInitialize, IGUI, IExecute
    {
        private Material _playerMaterial;
        private HealthController _healthPoints;
        private Color _color;
        private float _minHP = 0f;
        private float _maxHP = 5f;
        private float _slider = 0.0f;

        public PlayerDataController(Transform transform, HealthController healthController)
        {
            _playerMaterial = transform.GetComponent<Renderer>().material;
            _healthPoints = healthController;
        }

        public void Initialize()
        {
            _color = _playerMaterial.color;
        }

        public void Gui()
        {
            _color = RGBSlider(new Rect(10, 50, 200, 20), _color);
            _slider = HealthSlider(new Rect(10, 150, 200, 20), _slider, "Damage value");
        }

        Color RGBSlider(Rect screenRect, Color rgb)
        {
            rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
            screenRect.y += 20;
            rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");
            screenRect.y += 20;
            rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");
            screenRect.y += 20;
            rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "Alpha");
            return rgb;
        }

        float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
        {
            GUI.Label(screenRect, labelText);
            screenRect.x += screenRect.width;
            sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f, sliderMaxValue);
            return sliderValue;
        }

        float HealthSlider(Rect screenRect, float sliderValue, string labelText)
        {
            Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
            GUI.Label(labelRect, labelText);
            Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
            sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, _minHP, _maxHP);
            _healthPoints.HealthChange(sliderValue/100);
            return sliderValue;
        }

        public void Execute(float deltaTime)
        {
            _playerMaterial.SetColor("_Color",_color);
        }
    }
}
