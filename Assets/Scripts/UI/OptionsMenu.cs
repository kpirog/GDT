using UnityEngine;
using TMPro;

namespace GDT.UI
{
    public class OptionsMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI masterVolumeText;
        [SerializeField] private TextMeshProUGUI musicVolumeText;
        [SerializeField] private TextMeshProUGUI uiVolumeText;

        public void UpdateMasterVolume(float volume)
        {
            masterVolumeText.text = (volume * 100f).ToString("0.0");
        }

        public void UpdateMusicVolume(float volume)
        {
            musicVolumeText.text = (volume * 100f).ToString("0.0");
        }

        public void UpdateUIVolume(float volume)
        {
            uiVolumeText.text = (volume * 100f).ToString("0.0");
        }
    }
}