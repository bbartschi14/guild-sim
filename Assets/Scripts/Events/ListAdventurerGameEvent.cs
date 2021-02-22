using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/List Adventurer Game Event")]

public class ListAdventurerGameEvent : ScriptableObject
{
    private readonly List<ListAdventurerGameEventListener> eventListeners =
           new List<ListAdventurerGameEventListener>();

    public void Raise(List<Adventurer> advs)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(advs);
        }
    }

    public void RegisterListener(ListAdventurerGameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(ListAdventurerGameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

}
