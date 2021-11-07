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
        [SerializeField] private string _cameraPath;
        private PlayerBodyData _playerBody;
        private CameraData _cameraData;

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

        public CameraData CameraData
        {
            get
            {
                if(_cameraData == null)
                {
                    _cameraData = Load<CameraData>(_cameraPath);
                }
                return _cameraData;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
           Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}