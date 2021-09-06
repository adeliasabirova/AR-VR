using UnityEngine;

public class EnemyLifesVisualize : MonoBehaviour
{
    [SerializeField] private GameObject _healthBarUI;
    [SerializeField] private UnityEngine.UI.Slider _sldrHealth;
    [SerializeField] EnemyLifes enemyLifes;
    VisualizeHelath health;

    private void Start()
    {
        health = new VisualizeHelath();
        _sldrHealth.value = health.CalculateHealth(enemyLifes.CurrentHP, enemyLifes.MaxHP);
    }

    private void Update()
    {
        _sldrHealth.value = health.CalculateHealth(enemyLifes.CurrentHP, enemyLifes.MaxHP);
        if (enemyLifes.CurrentHP < enemyLifes.MaxHP)
        {
            _healthBarUI.SetActive(true);
        }
    }
}
