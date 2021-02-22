using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AdventurerGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public AdventurerGameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<Adventurer> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Adventurer adv)
    {
        Response.Invoke(adv);
    }
}
