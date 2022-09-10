using UnityEngine;
using TMPro; 

namespace GDT.UI
{
    public class FinishMenu : MonoBehaviour
    {
        [SerializeField] private GameObject finishPanel;
        [SerializeField] private TextMeshProUGUI sortingTimeText;
        [SerializeField] private SortingTimer sortingTimer;

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
            SetTimeText();
        }
        private void SetTimeText()
        {
            sortingTimeText.text = sortingTimer.SortingTime.ToString("0.00");
        }
    }
}
