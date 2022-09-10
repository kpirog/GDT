using System;

namespace GDT.Core
{
    public static class EventManager
    {
        public static event Action onGameStartedEvent;
        public static event Action onGamePausedEvent;
        public static event Action onGameResumedEvent;
        public static event Action onGameRestartedEvent;
        public static event Action onMenuOpenedEvent;

        public static event Action onSortingStartedEvent;
        public static event Action onSortingFinishedEvent;

        public static void OnGameStarted()
        {
            onGameStartedEvent?.Invoke();
        }

        public static void OnGamePaused()
        {
            onGamePausedEvent?.Invoke();
        }

        public static void OnGameResumed()
        {
            onGameResumedEvent?.Invoke();
        }

        public static void OnGameRestarted()
        {
            onGameRestartedEvent?.Invoke();
        }

        public static void OnMenuOpened()
        {
            onMenuOpenedEvent?.Invoke();
        }

        public static void OnSortingStarted()
        {
            onSortingStartedEvent?.Invoke();
        }

        public static void OnSortingFinished()
        {
            onSortingFinishedEvent?.Invoke();
        }
    }
}