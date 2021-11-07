using UnityEngine;
namespace Project
{
    internal sealed class CloudsController : IInitialize
    {
        private readonly CloudsData _cloudsData;
        private ParticleSystem _clouds;
        private ParticleSystemRenderer _cloudsRenderer;

        public CloudsController(CloudsData cloudsData, Transform clouds)
        {
            _cloudsData = cloudsData;
            _clouds = clouds.GetComponent<ParticleSystem>();
            _cloudsRenderer = clouds.GetComponent<ParticleSystemRenderer>();
        }
        public void Initialize()
        {
            var main = _clouds.main;
            main.startSize = _cloudsData.StartSize;
            main.startSpeed = _cloudsData.StartSpeed;

            var emission = _clouds.emission;
            emission.rateOverTime = _cloudsData.RateOverTime;


            var shape = _clouds.shape;
            shape.shapeType = _cloudsData.ShapeType;
            shape.scale = _cloudsData.ScaleBox;

            var colorOverLifetime = _clouds.colorOverLifetime;
            colorOverLifetime.enabled = true;
            colorOverLifetime.color = _cloudsData.Color;

            _cloudsRenderer.minParticleSize = _cloudsData.MinParticleSize;
            _cloudsRenderer.maxParticleSize = _cloudsData.MaxParticleSize;

            var noise = _clouds.noise;
            noise.enabled = true;
            noise.strength = _cloudsData.Strength;
            noise.frequency = _cloudsData.Frequency;
        }
    }
}
