using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
[CreateAssetMenu(menuName = "Events/Quest Game Event")]

public class QuestGameEvent : ScriptableObject
{
    private readonly List<QuestGameEventListener> eventListeners =
        new List<QuestGameEventListener>();

    public void Raise(Quest q)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(q);
        }
    }
    public void RegisterListener(QuestGameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }
    public void UnregisterListener(QuestGameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

}
