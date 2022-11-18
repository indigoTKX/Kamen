using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Animator _animator;

        [SerializeField] private float _MaxSideSpeed = 10f;
        [SerializeField] private float _sideAcceleration = 0.1f;

        //default value is 1/(pi * R)
        [SerializeField] private float _linearToAngularCoefficient = 1 / (3.14f * 0.12f);

        [Inject] private GameStateManager _gameStateManager;
        [Inject] private SpeedManager _speedManager;

        private bool _isMovingSideways = false;
        private float _xInput = 0f;
        private float _currentForwardSpeed = 0f;
        private float _currentSideSpeed = 0f;

        private readonly int _isMovingHash = Animator.StringToHash("isMoving");

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
            _playerTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            _gameStateManager.OnStateChanged += () =>
            {
                if (_gameStateManager.IsState(GameState.FirstPhase))
                {
                    _animator.SetBool(_isMovingHash, true);
                }
            };
        }

        private void Update()
        {
            _xInput = Input.GetAxis("Horizontal");
            if (_xInput != 0)
            {
                _isMovingSideways = true;
            }
        }

        private void FixedUpdate()
        {
            if (_gameStateManager.IsState(GameState.FirstPhase))
            {
                MovePlayer();
            }
        }

        private void MovePlayer()
        {
            var desiredPosition = _playerTransform.position;

            _currentForwardSpeed = _speedManager._currentForwardSpeed;
            if (_isMovingSideways)
            {
                _currentSideSpeed = _xInput * _MaxSideSpeed * Time.fixedDeltaTime;
                if (_currentSideSpeed < _MaxSideSpeed)
                {
                    _currentSideSpeed += _sideAcceleration * Time.fixedDeltaTime;
                }

                desiredPosition.x += _currentSideSpeed;
            }

            _playerTransform.position = desiredPosition;

            ChangeRotationSpeed(_currentForwardSpeed);
        }

        private void ChangeRotationSpeed(float newSpeed)
        {
            _animator.speed = newSpeed * _linearToAngularCoefficient;
        }
    }
}