using TKX1.Gameplay;
using UnityEngine;
using Zenject;

public class Phase1Installer : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private UpgradeLevelsList _upgradeLevelsList;
    
    public override void InstallBindings()
    {
         Container.Bind<Player>().FromInstance(_player).AsSingle();
         Container.Bind<UpgradeLevelsList>().FromInstance(_upgradeLevelsList).AsSingle();
    }
}
