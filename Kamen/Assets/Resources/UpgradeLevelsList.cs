using System.Collections.Generic;
using TKX1.Gameplay;
using UnityEngine;

namespace TKX1.Gameplay
{
    [CreateAssetMenu(fileName = "Upgrade levels", menuName = "Upgrade Levels List")]
    public class UpgradeLevelsList : ScriptableObject
    {
        [SerializeField] public List<UpgradeLevelInfo> Levels;
    }
}