using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
public class UIItem : MonoBehaviour
{
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _total;
    [SerializeField] private UIShop _ui;

    private IReset _reset;

    private void Awake()
    {
        _buttonBuy.onClick.AddListener(BuyItem);
        _reset = _ui.GetComponent<IReset>();
    }

    private void Start()
    {
        _reset.OnReset += OnResetChange;
        _price.text = Random.Range(10, 1000000).ToString();
    }

    private void OnResetChange()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            _price.text = Random.Range(10, 1000000).ToString();
        }
    }

    private void BuyItem()
    {
        _money.text = (float.Parse(_money.text) - float.Parse(_price.text)).ToString();
        _total.text = (float.Parse(_total.text) + float.Parse(_price.text)).ToString();
        gameObject.SetActive(false);   
    }

    private void OnDestroy()
    {
        _reset.OnReset -= OnResetChange;
    }
}
