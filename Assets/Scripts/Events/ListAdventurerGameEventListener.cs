using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListAdventurerGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public ListAdventurerGameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<List<Adventurer>> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(List<Adventurer> advs)
    {
        Response.Invoke(advs);
    }
}
