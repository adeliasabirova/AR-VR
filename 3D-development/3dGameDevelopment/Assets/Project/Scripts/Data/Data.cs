using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    { 
        [SerializeField] private string _playerPath;
        private PlayerBodyData _playerBody;

        public PlayerBodyData PlayerBody
        {
            get
            {
                if (_playerBody == null)
                {
                    _playerBody = Load<PlayerBodyData>(_playerPath);
                }
                return _playerBody;
            }
        }


        private T Load<T>(string resourcesPath) where T : Object =>
           Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}