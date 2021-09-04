using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Asteroids.Additional
{
    [CustomEditor(typeof(DictionarySerialization))]
    public class DictionarySerializationEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (((DictionarySerialization)target).modifyValues)
            {
                if (GUILayout.Button("Save changes"))
                {
                    ((DictionarySerialization)target).DeserializeDictionary();
                }

            }
        }
    }
}
