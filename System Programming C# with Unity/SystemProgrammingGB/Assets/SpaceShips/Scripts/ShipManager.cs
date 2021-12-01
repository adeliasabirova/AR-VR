using UnityEngine;
using UnityEngine.Networking;

namespace SpaceShips
{
    public class ShipManager : MonoBehaviour
    {
        public NetworkHash128 AssetId => _assetId;

        [SerializeField] private GameObject _shipPrefab;
        private NetworkHash128 _assetId;

        void Start()
        {
            _assetId = _shipPrefab.GetComponent<NetworkIdentity>().assetId;
            ClientScene.RegisterSpawnHandler(_assetId, SpawnShip, UnSpawnShip);
        }

        public GameObject SpawnShip(Vector3 position)
        {
            return Instantiate(_shipPrefab, position, Quaternion.identity);
        }

        public GameObject SpawnShip(Vector3 position, NetworkHash128 assetId)
        {
            return SpawnShip(position);
        }

        public void UnSpawnShip(GameObject spawned)
        {
            Destroy(spawned);
        }

    }
}