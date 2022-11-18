using System;
using UnityEngine;

namespace TKX1.Gameplay
{
    [Serializable] public class AudioInstance
    {
        public AudioClip Clip;
        public bool Loop;
        public float Volume;
        public AudioName AudioName;
    }
}