using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public enum GameEventsType
{
    PAUSE, RESUME, RESTART, FINISH, QUIT, MAINMENU, GAMEOVER
}

public class GameEventBus
{
    private static readonly IDictionary<GameEventsType, UnityEvent>
        Events = new Dictionary<GameEventsType, UnityEvent>();

    public static void Subcribe(GameEventsType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void UnSubcribe(GameEventsType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            Debug.Log(listener + eventType.ToString());
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(GameEventsType eventType)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
