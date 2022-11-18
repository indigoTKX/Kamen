using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TKX1.Gameplay
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private Vector3 _helmetOffset;

        private void Start()
        {
            _helmetOffset = transform.position - _player.position;
        }

        private void Update()
        {
            transform.position = _player.position + _helmetOffset;
        }
    }
}