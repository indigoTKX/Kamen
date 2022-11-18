using System;
using UnityEngine;
using Zenject;

namespace TKX1.Gameplay
{
    public class GateTrigger : MonoBehaviour
    {
        [SerializeField] private Gate _gate;
        
        [Inject] private Player _player;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Player>() is not null)
            {
                _player.SetPlayerLevel(_gate.Level);
            }
        }
    }
}