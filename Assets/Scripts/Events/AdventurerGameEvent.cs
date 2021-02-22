using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/Adventurer Game Event")]

public class AdventurerGameEvent : ScriptableObject
{
    private readonly List<AdventurerGameEventListener> eventListeners =
           new List<AdventurerGameEventListener>();

    public void Raise(Adventurer adv)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            
            eventListeners[i].OnEventRaised(adv);
        }
    }

    public void RegisterListener(AdventurerGameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(AdventurerGameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

}
