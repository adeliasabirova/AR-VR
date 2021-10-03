using UnityEngine;
using UnityEngine.UI;

namespace Homework1
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonHeal;
        [SerializeField]
        private Text _textHealth;
        [SerializeField]
        private Unit _unit;

        private void Awake()
        {
            _buttonHeal.onClick.AddListener(HealUnit);
        }

        private void HealUnit()
        {
            _unit.ReceiveHealing();
        }

        private void Update()
        {
            _textHealth.text = _unit.Health.ToString();
        }
    }
}
