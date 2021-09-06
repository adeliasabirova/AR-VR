using UnityEngine;

public class PlayerLifesVisualize: MonoBehaviour
{
    [SerializeField] private GameObject _barUI;
    [SerializeField] private UnityEngine.UI.Slider _sldrHealth;
    [SerializeField] private UnityEngine.UI.Slider _sldrBullets;


    [SerializeField] PlayerLifes playerLifes;
    [SerializeField] PlayerArmor playerArmor;

    VisualizeHelath health, bullets;

    private void Awake()
    {
#if UNITY_EDITOR
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
#endif

#if UNITY_STANDALONE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }

    private void Start()
    {
        health = new VisualizeHelath();
        _sldrHealth.value = health.CalculateHealth((float)playerLifes.CurrentHP, (float)playerLifes.MaxHP);
        bullets = new VisualizeHelath();
        _sldrBullets.value = bullets.CalculateHealth((float)playerArmor.CurrentBullets, (float)playerArmor.MaxBullets);
    }

    private void Update()
    {
        _sldrHealth.value = health.CalculateHealth((float)playerLifes.CurrentHP, (float)playerLifes.MaxHP);
        _sldrBullets.value = bullets.CalculateHealth((float)playerArmor.CurrentBullets, (float)playerArmor.MaxBullets);
        if (playerLifes.CurrentHP <= playerLifes.MaxHP && playerArmor.CurrentBullets <= playerArmor.MaxBullets)
        {
            _barUI.SetActive(true);
        }
    }
}
