using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace Galaxy
{
    internal sealed class CelestialBodyController : IInitialize, IExecute, ICleanUp
    {
        private readonly Data _data;
        private NativeArray<Vector3> _positions;
        private NativeArray<Vector3> _velocities;
        private NativeArray<Vector3> _accelerations;
        private NativeArray<float> _masses;
        private TransformAccessArray _transformAccessArray;

        public CelestialBodyController(Data data)
        {
            _data = data;
        }


        public void Initialize()
        {
            _positions = new NativeArray<Vector3>(_data.NumberOfIntities, Allocator.Persistent);
            _velocities = new NativeArray<Vector3>(_data.NumberOfIntities, Allocator.Persistent);
            _accelerations = new NativeArray<Vector3>(_data.NumberOfIntities, Allocator.Persistent);
            _masses = new NativeArray<float>(_data.NumberOfIntities, Allocator.Persistent);
            Transform[] transforms = new Transform[_data.NumberOfIntities];

            for(int i=0; i<_data.NumberOfIntities; i++)
            {
                _positions[i] = Random.insideUnitSphere * Random.Range(0, _data.CelestailBody.StartDistance);
                _velocities[i] = Random.insideUnitSphere * Random.Range(0, _data.CelestailBody.StartVelocity);
                _accelerations[i] = Vector3.zero;
                _masses[i] = Random.Range(1, _data.CelestailBody.StartMass);

                transforms[i] = Object.Instantiate(_data.CelestailBody.GetPrefab(), _positions[i], Quaternion.identity).transform;
            }
            _transformAccessArray = new TransformAccessArray(transforms);
        }

        public void Execute(float deltaTime)
        {
            GravitationJob gravitationJob = new GravitationJob()
            {
                Positions = _positions,
                Velocities = _velocities,
                Accelerations = _accelerations,
                Masses = _masses,
                GravitationModifier = _data.CelestailBody.GravitationalModifier,
                DeltaTime = deltaTime
            };
            JobHandle gravitationHandle = gravitationJob.Schedule(_data.NumberOfIntities, 0);

            MovementJov movementJov = new MovementJov()
            {
                Positions = _positions,
                Velocities = _velocities,
                Accelerations = _accelerations,
                DeltaTime = deltaTime
            };
            JobHandle movementhandle = movementJov.Schedule(_transformAccessArray, gravitationHandle);
            movementhandle.Complete();

            RotationJob rotationJob = new RotationJob()
            {
                Velocities = _velocities,
                DeltaTime = deltaTime
            };
            JobHandle rotationHandle = rotationJob.Schedule(_transformAccessArray);
            rotationHandle.Complete();

        }

        public void CleanUp()
        {
            _positions.Dispose();
            _velocities.Dispose();
            _accelerations.Dispose();
            _masses.Dispose();
            _transformAccessArray.Dispose();
        }
    }
}