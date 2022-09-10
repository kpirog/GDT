using GDT.UI;
using GDT.Core;
using UnityEngine;

namespace GDT.Timer
{
    public class SortingTimer : MonoBehaviour
    {
        [SerializeField] private GameInfoUI gameInfoUI;
        [SerializeField] private FinishMenu finishMenu;

        private bool canCount = false;
        private float sortingTime = 0f;
        private float savedTime = 0f;

        public float SortingTime => sortingTime;

        private void OnEnable()
        {
            EventManager.onGameStartedEvent += RestartTimer;
            EventManager.onGameRestartedEvent += RestartTimer;
        }

        private void OnDisable()
        {
            EventManager.onGameStartedEvent -= RestartTimer;
            EventManager.onGameRestartedEvent -= RestartTimer;
        }

        private void Update()
        {
            if (canCount)
            {
                sortingTime = Time.time - savedTime;
                gameInfoUI.SetTimeView(sortingTime);
                finishMenu.SetTimeText(sortingTime);
            }
        }

        private void RestartTimer()
        {
            canCount = true;
            savedTime = Time.time;
            sortingTime = 0f;
        }
    }
}