using System;
using System.Collections.Generic;
using UnityEngine;

namespace TKX1.Gameplay
{
    public class LevelViewer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _levelModels;
        [SerializeField] private Player _player;

        private void Awake()
        {
            _player.Initialize(ChangePlayerView);
        }

        private void ChangePlayerView(int newLevel)
        {
            _levelModels[newLevel].SetActive(true);
            _levelModels[_player.PlayerLevel].SetActive(false);
        }
    }
}