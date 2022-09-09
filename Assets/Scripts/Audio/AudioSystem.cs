using UnityEngine;

namespace GDT.Audio
{
    public class AudioSystem : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip buttonSFX;

        public void PlayButtonSFX()
        {
            audioSource.PlayOneShot(buttonSFX);
        }
    }
}