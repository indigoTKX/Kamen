using TKX1.Gameplay;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ManagerInstaller", menuName = "Installers/ManagerInstaller")]
public class ManagerInstaller : ScriptableObjectInstaller<ManagerInstaller>
{
    [SerializeField] private GameStateManager _gameStateManagerPrefab;
    [SerializeField] private SpeedManager _speedManagerPrefab;
    [SerializeField] private AudioManager _audioManagerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<GameStateManager>().FromComponentInNewPrefab(_gameStateManagerPrefab).AsSingle();
        Container.Bind<SpeedManager>().FromComponentInNewPrefab(_speedManagerPrefab).AsSingle();
        Container.Bind<AudioManager>().FromComponentInNewPrefab(_audioManagerPrefab).AsSingle();
    }
}