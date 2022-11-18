using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TKX1.Gameplay
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private List<AudioInstance> _audioList;
        [SerializeField] private AudioSource _sourcePrefab;
        
        private List<AudioSource> _sources;

        protected void Awake()
        {
            _sources = new List<AudioSource>();
        }

        private void Start()
        {
            PlayAudio(AudioName.BackgroundMusic);
        }

        public void PlayAudio(AudioName audioName)
        {
            var source = PickSource();

            var audioInstance = _audioList.FirstOrDefault(item => item.AudioName == audioName);
            if (audioInstance == null) return;

            source.loop = audioInstance.Loop;
            source.clip = audioInstance.Clip;
            source.volume = audioInstance.Volume;
            source.Play();
        }

        private AudioSource PickSource()
        {
            AudioSource vacantSource = null;
            foreach (var source in _sources)
            {
                if (source.isPlaying) continue;
                vacantSource = source;
            }
            if (vacantSource != null) return vacantSource;
            
            vacantSource = Instantiate(_sourcePrefab, transform);
            _sources.Add(vacantSource);
            return vacantSource;
        }
    }

    

    public enum AudioName
    {
        BackgroundMusic,
        RollingStone,
        DroneCollision
    }
}