using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    internal sealed class PanelOne : BaseUI
    {
        [SerializeField] private Text _textScore;
        [SerializeField] private Text _textDamage;

        public override void Execute(Dictionary<string, string> list)
        {
            _textScore.text = "Score: " + list["score"];
            _textDamage.text = "Damage: " + list["damage"];
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        
    }
}