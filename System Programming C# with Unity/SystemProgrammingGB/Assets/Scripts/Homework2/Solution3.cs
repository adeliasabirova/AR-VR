using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace Homework2
{
    public class Solution3 : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5f;
        [SerializeField]
        private GameObject _unitPrefab;
        [SerializeField]
        private int _numberOfIntities = 5;

        private TransformAccessArray _transformAccessArray;


        private void Start()
        {
            Transform[] transforms = new Transform[_numberOfIntities];
            for (int i=0; i< _numberOfIntities; i++)
            {
                var position = Random.insideUnitSphere * Random.Range(0, 5);
                transforms[i] = Instantiate(_unitPrefab, position, Quaternion.identity).transform;
            }
            _transformAccessArray = new TransformAccessArray(transforms);
        }

        private void Update()
        {
            AdvancedJobForTransform job = new AdvancedJobForTransform()
            {
                DeltaTime = Time.deltaTime,
                Speed = _speed
            };
            JobHandle handle = job.Schedule(_transformAccessArray);
            handle.Complete();
        }

        private void OnDestroy()
        {
            _transformAccessArray.Dispose();
        }
    }
}
