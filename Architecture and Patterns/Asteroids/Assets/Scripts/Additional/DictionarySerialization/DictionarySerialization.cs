using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Additional
{
    public sealed class DictionarySerialization : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField]
        private DictionaryScriptableObject _dictionaryData;
        [SerializeField]
        private List<string> _keys = new List<string>();
        [SerializeField]
        private List<int> _values = new List<int>();

        private Dictionary<string, int> _dictionary = new Dictionary<string, int>();

        public bool modifyValues;

        public void OnBeforeSerialize()
        {
            if(modifyValues == false)
            {
                _keys.Clear();
                _values.Clear();
                for (int i = 0; i < Mathf.Min(_dictionaryData.Keys.Count, _dictionaryData.Values.Count); i++)
                {
                    _keys.Add(_dictionaryData.Keys[i]);
                    _values.Add(_dictionaryData.Values[i]);
                }
            }
        }

        public void OnAfterDeserialize()
        {
            
        }

        public void DeserializeDictionary()
        {
            Debug.Log("DESERIALIZATION");
            _dictionary = new Dictionary<string, int>();
            _dictionaryData.Keys.Clear();
            _dictionaryData.Values.Clear();
            for (int i = 0; i < Mathf.Min(_keys.Count, _values.Count); i++)
            {
                _dictionaryData.Keys.Add(_keys[i]);
                _dictionaryData.Values.Add(_values[i]);
                _dictionary.Add(_keys[i], _values[i]);
            }
            modifyValues = false;
        }
    }
}
