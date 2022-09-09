using UnityEngine;

namespace GDT.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;

        public void PauseButton()
        {
            EventManager.OnGamePaused();
            TogglePanel(true);
        }
        public void ResumeButton()
        {
            EventManager.OnGameResumed();
            TogglePanel(false);
        }
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
            pausePanel.SetActive(open);
        }
    }
}