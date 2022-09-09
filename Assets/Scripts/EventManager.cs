using System;

public static class EventManager 
{
    public static event Action onGameStartedEvent;
    public static event Action onSortingStartedEvent;

    public static void OnGameStarted()
    {
        onGameStartedEvent?.Invoke();
    }
    public static void OnSortingStarted()
    {
        onSortingStartedEvent?.Invoke();
    }
}
