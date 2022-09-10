using UnityEngine;
using UnityEngine.Audio;

namespace GDT.Audio
{
    public class AudioSystem : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private AudioSource uiAudioSource;
        [SerializeField] private AudioClip buttonSFX;

        private const string MASTER_KEY = "MasterVolume";
        private const string MUSIC_KEY = "MusicVolume";
        private const string UI_KEY = "UIVolume";

        public void PlayButtonSFX()
        {
            uiAudioSource.PlayOneShot(buttonSFX);
        }

        public void SetMasterVolume(float value)
        {
            audioMixer.SetFloat(MASTER_KEY, Mathf.Log10(value) * 20f);
        }

        public void SetMusicVolume(float value)
        {
            audioMixer.SetFloat(MUSIC_KEY, Mathf.Log10(value) * 20f);
        }

        public void SetUIVolume(float value)
        {
            audioMixer.SetFloat(UI_KEY, Mathf.Log10(value) * 20f);
        }
    }
}