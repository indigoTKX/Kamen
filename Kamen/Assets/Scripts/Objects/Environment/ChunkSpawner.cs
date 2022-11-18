using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class ChunkSpawner : MonoBehaviour
    {
        [SerializeField] private DestroyableEnvironment _chunkPrefab;
        [SerializeField] private float _chunkSize = 10f;

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        private DestroyableEnvironment _lastChunk;

        private void Start()
        {
            for (int i = 0; i < 9; i++)
            {
                SpawnChunk(transform.position + Vector3.forward * _chunkSize * i);
            }
        }

        private void SpawnChunk(Vector3 spawnPoint)
        {
            var lastChunkGameObject = _diContainer.InstantiatePrefab(_chunkPrefab, spawnPoint, Quaternion.identity, null);
            _lastChunk = lastChunkGameObject.GetComponent<DestroyableEnvironment>();
            
            _lastChunk.Initialize(
                chunk =>
                {
                    var newSpawnPoint = _lastChunk.transform.position + Vector3.forward * _chunkSize;
                    RespawnChunk(newSpawnPoint, chunk);
                });
        }

        private void RespawnChunk(Vector3 spawnPoint, DestroyableEnvironment chunk)
        {
            _lastChunk = chunk;
            chunk.transform.position = spawnPoint;
        }
    }
}