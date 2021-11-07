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
        [SerializeField] private string _lightingPath;
        [SerializeField] private string _firefliesPath;
        [SerializeField] private string _cloudsPath;

        private PlayerBodyData _playerBody;
        private CameraData _cameraData;
        private LightingData _lightingData;
        private FirefliesData _firefliesData;
        private CloudsData _cloudsData;

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

        public LightingData LightingData
        {
            get
            {
                if(_lightingData == null)
                {
                    _lightingData = Load<LightingData>(_lightingPath);
                }
                return _lightingData;
            }
        }

        public FirefliesData FirefliesData
        {
            get
            {
                if (_firefliesData == null)
                {
                    _firefliesData = Load<FirefliesData>(_firefliesPath);
                }
                return _firefliesData;
            }
        }

        public CloudsData CLoudsData
        {
            get
            {
                if (_cloudsData == null)
                {
                    _cloudsData = Load<CloudsData>(_cloudsPath);
                }
                return _cloudsData;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
           Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}