using UnityEngine;
using GDT.Core;
using TMPro; 

namespace GDT.UI
{
    public class FinishMenu : MonoBehaviour
    {
        [SerializeField] private GameObject finishPanel;
        [SerializeField] private TextMeshProUGUI sortingTimeText;

        public void RestartButton()
        {
            EventManager.OnGameRestarted();
            EventManager.OnGameStarted();
            TogglePanel(false);
        }

        public void MainMenuButton()
        {
            EventManager.OnMenuOpened();
            TogglePanel(false);
        }

        public void TogglePanel(bool open)
        {
            finishPanel.SetActive(open);
        }

        public void SetTimeText(float time)
        {
            sortingTimeText.text = time.ToString("0.00");
        }
    }
}
