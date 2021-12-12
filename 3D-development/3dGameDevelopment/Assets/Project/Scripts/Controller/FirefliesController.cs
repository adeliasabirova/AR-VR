using UnityEngine;
namespace Project
{
    internal sealed class FirefliesController : IInitialize
    {
        private readonly FirefliesData _firefliesData;
        private ParticleSystem _fireflies;

        public FirefliesController(FirefliesData firefliesData, Transform fireflies)
        {
            _firefliesData = firefliesData;
            _fireflies = fireflies.GetComponent<ParticleSystem>();
        }
        public void Initialize()
        {
            var main = _fireflies.main;
            main.startSize = _firefliesData.StartSize;
            main.startSpeed = _firefliesData.StartSpeed;

            var emission = _fireflies.emission;
            emission.enabled = true;
            emission.rateOverTime = _firefliesData.RateOverTime;
           

            var shape = _fireflies.shape;
            shape.enabled = true;
            shape.shapeType = _firefliesData.ShapeType;
            shape.scale = _firefliesData.ScaleBox;

            var colorOverLifetime = _fireflies.colorOverLifetime;
            colorOverLifetime.enabled = true;
            colorOverLifetime.color = _firefliesData.Color;

            var sizeOverLifetime = _fireflies.sizeOverLifetime;
            sizeOverLifetime.enabled = true;
            sizeOverLifetime.size = _firefliesData.Curve;

            var noise = _fireflies.noise;
            noise.enabled = true;
            noise.strength = _firefliesData.Strength;
            noise.frequency = _firefliesData.Frequency;
        }
    }
}
