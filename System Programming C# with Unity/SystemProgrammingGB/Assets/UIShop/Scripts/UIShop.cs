using System;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour, IReset
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _panelShop;

    [SerializeField] private Button _buttonOpen;
    [SerializeField] private Button _buttonClose;
    [SerializeField] private Button _buttonReset;

    public event Action OnReset;

    private void Awake()
    {
        _buttonOpen.onClick.AddListener(OpenShop);
        _buttonClose.onClick.AddListener(CloseShop);
        _buttonReset.onClick.AddListener(ResetShop);
    }

    private void ResetShop()
    {
        OnReset?.Invoke();
    }

    private void CloseShop()
    {
        _panelShop.SetActive(false);
        _panelMenu.SetActive(true);
    }

    private void OpenShop()
    {
        _panelMenu.SetActive(false);
        _panelShop.SetActive(true);
    }
}
