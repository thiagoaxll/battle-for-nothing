using UnityEngine;
using UnityEngine.Audio;

namespace CustomSystem.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        public AudioMixer audioMixer;
        
        [SerializeField] private AudioSource effectAudioSource;
        [SerializeField] private AudioSource musicAudioSource;
        [SerializeField] private float masterVolume;
        [SerializeField] private float effectVolume;
        [SerializeField] private float musicVolume;

        public void SetMasterVolume(int vol)
        {
            masterVolume = vol;
            ApplyVolumeChanges();
        }

        public void SetEffectVolume(float vol)
        {
            effectVolume = vol;
            ApplyVolumeChanges();
        }

        public void SetMusicVolume(float vol)
        {
            musicVolume = vol;
            ApplyVolumeChanges();
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            DontDestroyOnLoad(this);
            ApplyVolumeChanges();
        }

        public void PlayAudio(AudioClip soundClip, AudioType type = AudioType.Effect)
        {
            if (type == AudioType.Effect)
            {
                effectAudioSource.PlayOneShot(soundClip);
            }
            else
            {
                musicAudioSource.PlayOneShot(soundClip);
            }
        }

        public void ApplyVolumeChanges()
        {
            audioMixer.SetFloat("Master", masterVolume - 80);
            audioMixer.SetFloat("Effect", effectVolume - 80);
            audioMixer.SetFloat("Music", musicVolume - 80);
        }

        public enum AudioType
        {
            Music,
            Effect
        }
    }
}