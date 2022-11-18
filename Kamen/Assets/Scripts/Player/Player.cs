using System;
using UnityEngine;

namespace TKX1.Gameplay
{
    public class Player : MonoBehaviour
    {
        [field:SerializeField] public int PlayerLevel {get; private set;}
        [field:SerializeField] public int MaxLevel {get; private set;}
        
        private Action<int> OnLevelChanged = null;

        public void SetPlayerLevel(int newLevel)
        {
            if (newLevel > MaxLevel)
            {
                newLevel = MaxLevel;
            }
            
            OnLevelChanged?.Invoke(newLevel);
            PlayerLevel = newLevel;
        }

        public void Initialize(Action<int> action)
        {
            OnLevelChanged = action;
        }
    }
}