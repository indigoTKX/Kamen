using System;
using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _redMaterial;
        
        [field:SerializeField] public int Level {get; private set;}

        [Inject] private Player _player;
        
        private Action<int> OnLevelChanged = null;
        
        public void SetLevel(int newLevel)
        {
            if (newLevel > _player.MaxLevel)
            {
                newLevel = _player.MaxLevel;
            }
            
            OnLevelChanged?.Invoke(newLevel);
            Level = newLevel;
            if (Level <= _player.PlayerLevel)
            {
                _meshRenderer.material = _redMaterial;
            }
        }

        public void Initialize(Action<int> action)
        {
            OnLevelChanged += action;
        }
    }
}