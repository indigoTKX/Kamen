using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
   public class ObstacleSpawner : SpawnerBase
   {
      [SerializeField] private List<Transform> _points;
      [SerializeField] private GameObject _obstaclePrefab;

      [Inject] private GameStateManager _gameStateManager;
      
      private DiContainer _diContainer;

      [Inject]
      private void Construct(DiContainer diContainer)
      {
         _diContainer = diContainer;
      }

      private void Start()
      {
         _gameStateManager.OnStateChanged += OnStateChanged;
      }

      private void OnStateChanged()
      {
         if (_gameStateManager.CurrentState.Equals(GameState.FirstPhase))
         {
            Launch();
         }
      }

      protected override void Spawn()
      {
         int gapAmount = Random.Range(1, 3);
         var spawnPoints = new List<Transform>();
         spawnPoints.AddRange(_points);

         for (int i = 0; i < gapAmount; i++)
         {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            spawnPoints.RemoveAt(randomIndex);
         }

         foreach (var t in spawnPoints)
         {
            //Instantiate(_obstaclePrefab, t.position, t.rotation);
            _diContainer.InstantiatePrefab(_obstaclePrefab, t.position, t.rotation,null);
         }
      }
   }
}