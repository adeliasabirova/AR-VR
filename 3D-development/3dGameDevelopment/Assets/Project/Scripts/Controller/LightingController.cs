using UnityEngine;

namespace Project
{
    internal sealed class LightingController : IInitialize, IExecute
    {
        private readonly LightingData _lightingData;
        private float _timeRate;
        private float _time;
        private Light _sun;
        private Light _moon;

        public LightingController(LightingData lightingData, Light sun, Light moon)
        {
            _lightingData = lightingData;
            _sun = sun;
            _moon = moon;
        }

        public void Initialize()
        {
            _timeRate = 1.0f / _lightingData.FullDayLength;
            _time = _lightingData.StartTime;
        }

        public void Execute(float deltaTime)
        {
            _time += _timeRate * deltaTime;
            if (_time >= 1.0f) _time = 0.0f;

            _sun.transform.eulerAngles = (_time - 0.25f) * _lightingData.Noon * _lightingData.LightingOffset;
            _moon.transform.eulerAngles = (_time - 0.75f) * _lightingData.Noon * _lightingData.LightingOffset;
            _sun.intensity = _lightingData.SunIntensity.Evaluate(_time);
            _moon.intensity = _lightingData.MoonIntensity.Evaluate(_time);

            _sun.color = _lightingData.SunColor.Evaluate(_time);
            _moon.color = _lightingData.MoonColor.Evaluate(_time);

            if (_sun.intensity == 0 && _sun.gameObject.activeInHierarchy)
                _sun.gameObject.SetActive(false);
            else if (_sun.intensity > 0 && !_sun.gameObject.activeInHierarchy)
                _sun.gameObject.SetActive(true);

            if (_moon.intensity == 0 && _moon.gameObject.activeInHierarchy)
                _moon.gameObject.SetActive(false);
            else if (_moon.intensity > 0 && !_moon.gameObject.activeInHierarchy)
                _moon.gameObject.SetActive(true);

            RenderSettings.ambientIntensity = _lightingData.LightingIntensityMultiplier.Evaluate(_time);
            RenderSettings.reflectionIntensity = _lightingData.ReflectionsIntensityMultiplier.Evaluate(_time);
        }
    }
}
