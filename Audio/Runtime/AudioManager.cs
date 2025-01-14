using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

namespace ModulesGT.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private AudioConfig[] audioConfigs;

        private List<AudioSource> audioSources;
        private const string SoundFxParam = "Effects";
        private const string MusicParam = "Music";

        private void Awake()
        {
            audioSources = new List<AudioSource>(GetComponents<AudioSource>());
        }

        public void Play(AudioType audioType)
        {
            var config = audioConfigs.FirstOrDefault(c => c.AudioType == audioType);
            if (config == null)
            {
                Debug.LogError($"AudioConfig for {audioType} is not found. Please check the configuration.");
                return;
            }

            if (IsPlaying(config, out var activeSource) && activeSource.loop)
            {
                activeSource.Stop();
            }

            var source = GetOrCreateAudioSource();
            source.clip = config.Clip;
            source.outputAudioMixerGroup = config.AudioMixerGroup;
            source.loop = config.Loop;
            source.volume = config.Volume;
            source.Play();
        }

        public void SetSoundFx(bool isEnabled)
        {
            audioMixer.SetFloat(SoundFxParam, isEnabled ? 0 : -80);
        }

        public void SetMusic(bool isEnabled)
        {
            audioMixer.SetFloat(MusicParam, isEnabled ? 0 : -80);
        }

        private AudioSource GetOrCreateAudioSource()
        {
            var source = audioSources.FirstOrDefault(s => !s.isPlaying);
            if (source == null)
            {
                source = gameObject.AddComponent<AudioSource>();
                audioSources.Add(source);
            }

            return source;
        }

        private bool IsPlaying(AudioConfig config, out AudioSource source)
        {
            source = audioSources.FirstOrDefault(s => s.clip == config.Clip);
            return source != null && source.isPlaying;
        }
    }
}