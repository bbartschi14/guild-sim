using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldManager : MonoBehaviour
{
    [Header("Adventurer Controls")]
    public AdventurerGenerator adventurerGenerator;
    public AdventurerGameEvent onPresentAdventurerEvent;
    [Header("Quest Controls")]
    public QuestGenerator questGenerator;
    public QuestGameEvent onPresentQuestEvent;
    [Header("Client Controls")] 
    public GameObject clientPrefab;
    public Vector2 clientSpawnRangeX;
    public Vector2 clientSpawnRangeZ;
    public Transform clientsRoot;
    [Header("Time Controls")]
    public IntVariable time;
    public GameEvent onTimeAdvanced;

    private int numClients = 0;
    /*
     * Advance the world time by one step, and 
     * trigger the time change event for other
     * listeners.
     */
    public void AdvanceTime()
    {
        time.ApplyChange(1);
        onTimeAdvanced.Raise();
    }

    /*
     * Present a new adventurer for the guild,
     * with the option to hire them for a given amount.
     */
    public void PresentNewAdventurer()
    {
        Adventurer adv = adventurerGenerator.GenerateAdventurer();
        onPresentAdventurerEvent.Raise(adv);
    }
    
    /*
     * Present a new quest for the guild.
     */
    public void PresentNewQuest()
    {
        Quest q = questGenerator.GenerateQuest();
        onPresentQuestEvent.Raise(q);
    }

    public void SpawnClient()
    {
        GameObject client = Instantiate(clientPrefab, clientsRoot);
        client.transform.position = RandomClientPosition();
        ClientController cc = client.GetComponent<ClientController>();
        Quest q = questGenerator.GenerateQuest();
        cc.id = numClients;
        q.ClientID = cc.id;
        cc.quest = q;

        numClients++;
    }

    private Vector3 RandomClientPosition()
    {
        float x = Random.Range(clientSpawnRangeX.x, clientSpawnRangeX.y);
        float z = Random.Range(clientSpawnRangeZ.x, clientSpawnRangeZ.y);
        return new Vector3(x, 0f, z);

    }
}
