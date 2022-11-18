using System;
using UnityEngine;

namespace TKX1.Gameplay
{
    public class GameStateManager : MonoBehaviour
    {
        public GameState CurrentState { get; private set; }

        public event Action OnStateChanged;
        
        public bool IsState(GameState state)
        {
            return CurrentState.Equals(state);
        }

        public void SetState(GameState state)
        {
            CurrentState = state;
            OnStateChanged?.Invoke();
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            if (CurrentState.Equals(GameState.Prepare))
            {
                SetState(GameState.FirstPhase);
            }
        }
    }
    
    public enum GameState
    {
        Prepare,
        FirstPhase,
        SecondPhase,
        End
    }
}


