namespace Galaxy
{
    internal sealed class GalaxyInitialization
    {
        public GalaxyInitialization(Controllers controlles, Data data)
        {
            controlles.Add(new CelestialBodyController(data));
        }
    }
}