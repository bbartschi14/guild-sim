using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class QuestGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public QuestGameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<Quest> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Quest q)
    {
        Response.Invoke(q);
    }
}
