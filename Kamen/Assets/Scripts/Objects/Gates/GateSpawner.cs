using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TKX1.Gameplay
{
    public class GateSpawner : SpawnerBase
    {
        [SerializeField] private Transform _leftSpawnPoint;
        [SerializeField] private Transform _rightSpawnPoint;
        
        [Space] 
        [SerializeField] private Gate _gatePrefab;

        private DiContainer _diContainer;
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        [Inject] private GameStateManager _gameStateManager;
        [Inject] private Player _player;

        private Gate _leftGate;
        private Gate _rightGate;

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
            _leftGate= _diContainer.InstantiatePrefabForComponent<Gate>(_gatePrefab, _leftSpawnPoint);

            _rightGate = _diContainer.InstantiatePrefabForComponent<Gate>(_gatePrefab, _rightSpawnPoint);

            //_leftGate = Instantiate(_gatePrefab, _leftSpawnPoint);
            //_rightGate = Instantiate(_gatePrefab, _rightSpawnPoint);

            int buffLevel = Random.Range(_player.PlayerLevel + 1, _player.MaxLevel + 1);
            int debuffLevel = Random.Range(0, _player.PlayerLevel + 1);

            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 1)
            {
                _rightGate.SetLevel(buffLevel);
                _leftGate.SetLevel(debuffLevel);
            }
            else
            {
                _rightGate.SetLevel(debuffLevel);
                _leftGate.SetLevel(buffLevel);
            }
        }
    }
}
