using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TKX1.Gameplay
{
    public class GateUI : MonoBehaviour
    {
        [SerializeField] private Gate _gate;
        
        [SerializeField] private TextMeshProUGUI _levelName;
        [SerializeField] private Image _levelIcon;
        
        [Inject] private UpgradeLevelsList _upgradeLevels;

        private void Awake()
        {
            _gate.Initialize(SetUpgradeLevel);
        }

        private void SetUpgradeLevel(int level)
        {
            _levelName.text = _upgradeLevels.Levels[level].LevelName;
            _levelIcon.sprite = _upgradeLevels.Levels[level].LevelIcon;
        }
    }
}