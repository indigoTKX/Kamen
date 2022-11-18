using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class SpeedManager : MonoBehaviour
    {
        [SerializeField] private float _maxForwardSpeed = 300f;
        [SerializeField] private float _forwardAcceleration = 0.05f;
        
        [Inject] private GameStateManager _gameStateManager;

        public float _currentForwardSpeed = 0f;
        
        private void FixedUpdate()
        {
            if (!_gameStateManager.IsState(GameState.FirstPhase)) return;

            if (_currentForwardSpeed < _maxForwardSpeed)
            {
                _currentForwardSpeed += _forwardAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                _currentForwardSpeed = _maxForwardSpeed;
            }

        }
    }
}