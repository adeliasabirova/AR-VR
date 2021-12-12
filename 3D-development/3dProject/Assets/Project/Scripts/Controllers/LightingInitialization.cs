﻿using UnityEngine;

namespace Game
{
    internal sealed class LightingInitialization : IInitialize
    {
        private readonly LightingData _lightingData;
        private Light _sun;
        private Light _moon;

        public LightingInitialization(LightingData lightingData)
        {
            _lightingData = lightingData;
            _sun = Object.Instantiate(_lightingData.Sun).GetComponent<Light>();
            _moon = Object.Instantiate(_lightingData.Moon).GetComponent<Light>();
        }
        public void Initialize()
        {
            
        }

        public Light Sun => _sun;
        public Light Moon => _moon;
    }
}
