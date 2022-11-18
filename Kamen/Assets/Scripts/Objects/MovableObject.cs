using System;
using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class MovableObject : MonoBehaviour, IMovable
    {
        [SerializeField] private Transform _transform;

        [Inject] private GameStateManager _gameStateManager;
        [Inject] private SpeedManager _speedManager;

        private float _currentForwardSpeed = 0f;

        private void OnValidate()
        {
            _transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            if (!_gameStateManager.IsState(GameState.FirstPhase)) return;
            Move();
        }

        public void Move()
        {
            var desiredPosition = _transform.position;
            _currentForwardSpeed = _speedManager._currentForwardSpeed;
            desiredPosition.z -= _currentForwardSpeed;
            _transform.position = desiredPosition;
        }
    }
}