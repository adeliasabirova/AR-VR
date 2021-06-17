public class VisualizeHelath : ICalculateHealth
{
    public float CalculateHealth(float currentHP, float maxHP)
    {
        return currentHP / maxHP;
    }
}
