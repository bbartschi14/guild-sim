using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientController : MonoBehaviour
{
    public QuestGameEvent onQuestPresented;
    public Quest quest;
    private bool presenting = true;
    public GameObject hasQuestIndicator;
    public int id;
    public float moveSpeed = 1f;
    public void onHandlerClicked()
    {
        if (quest != null && presenting)
        {
            onQuestPresented.Raise(quest);
            
        }
    }

    public void onQuestHandled(Quest q)
    {
        //Debug.Log("Client #" + id + " with quest " + q.ClientID);
        if (presenting && id == q.ClientID)
        {
            presenting = false;
            SetQuestIndication(false);
            Vector3 moveTo = new Vector3(0f, 0f, -5f);
            float dist = Vector3.Distance(transform.position, moveTo);
            //Debug.Log("Distance " + dist +", time to dest: " + (dist/moveSpeed));
            LeanTween.move(gameObject, moveTo, dist/moveSpeed).setDelay(.25f).setOnComplete(DestroyClient);
        }
    }

    public void SetQuestIndication(bool value)
    {
        presenting = value;
        hasQuestIndicator.SetActive(value);
    }

    public void DestroyClient()
    {
        Destroy(gameObject);
    }
}
