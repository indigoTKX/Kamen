using System.Collections;
using UnityEngine;

namespace TKX1.Gameplay
{
    public abstract class SpawnerBase : MonoBehaviour
    {
        [SerializeField] protected float SpawnDelay = 1f;
        
        protected bool IsSpawning;
        protected abstract void Spawn();

        /// <summary>
        /// Starts coroutine, which calls Spawn() every SpawnDelay seconds 
        /// </summary>
        protected void Launch()
        {
            IsSpawning = true;
            StartCoroutine(ConstantDelayedSpawn());
        }

        private IEnumerator ConstantDelayedSpawn()
        {
            while (IsSpawning)
            {
                Spawn();
                yield return new WaitForSeconds(SpawnDelay);
            }
        }
    }
}

