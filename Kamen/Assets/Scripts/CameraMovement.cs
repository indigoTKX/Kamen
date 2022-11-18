using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class CameraMovement : MonoBehaviour
    {

        [SerializeField] private Transform _player;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothSpeed = 10f;

        //private bool _started;
        private bool _rotated = true;

        [Inject] private GameStateManager _gameStateManager;

        private void Update()
        {
            var cameraTransform = transform;
            if (_rotated && _gameStateManager.IsState(GameState.FirstPhase))
            {
                RotateOnStart(cameraTransform);
            }

            if (_gameStateManager.IsState(GameState.FirstPhase))
            {
                FollowPlayer(cameraTransform);
            }
        }

        private void RotateOnStart(Transform cameraTransform)
        {
            var desiredRotation = Quaternion.Euler(0, 0, 0);
            var smoothedRotation =
                Quaternion.Lerp(cameraTransform.rotation, desiredRotation, _smoothSpeed * Time.deltaTime);
            cameraTransform.rotation = smoothedRotation;
            if (smoothedRotation == desiredRotation) _rotated = false;
        }

        private void FollowPlayer(Transform cameraTransform)
        {
            var desiredPosition = _player.position + _offset;
            var smoothedPosition =
                Vector3.Lerp(cameraTransform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
            cameraTransform.position = smoothedPosition;
        }
    }
}