using System;
using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class ObstacleCollisions : MonoBehaviour
    {
        [Inject] private AudioManager _audioManager;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Player>() is not null)
            {
                CollisionWithPlayer();
            }
        }

        private void CollisionWithPlayer()
        {
            _audioManager.PlayAudio(AudioName.DroneCollision);
            Destroy(gameObject);
        }
    }
}