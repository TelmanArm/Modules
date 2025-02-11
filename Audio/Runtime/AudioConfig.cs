using UnityEngine;
using UnityEngine.Audio;

namespace ModulesGT.Audio
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Modules/Audio/AudioConfig")]
    public class AudioConfig : ScriptableObject
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioMixerGroup mixerGroup;
        [SerializeField] private bool loop;
        [Range(0.1f, 1f)] [SerializeField] private float volume;
        public AudioClip Clip => clip;
        public AudioMixerGroup AudioMixerGroup => mixerGroup;
        public bool Loop => loop;
        public float Volume => volume;
    }
}