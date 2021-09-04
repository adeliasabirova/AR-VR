using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    internal sealed class PanelTwo : BaseUI
    {
        [SerializeField] private Text _text;
        [SerializeField] private float _durationOfText = 1.0f;

        public override void Execute(Dictionary<string, string> dictionary)
        {
            _text.text = dictionary["enemy"];
            _text.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255));
            gameObject.SetActive(true);
        }


        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}