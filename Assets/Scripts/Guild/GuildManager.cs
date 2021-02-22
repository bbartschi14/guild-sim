using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GuildManager : MonoBehaviour
{
    public IntVariable gold;
    public IntVariable rank;
    public GameObject adventurerList;
    public UnityEvent onQuestStatusChanged;
    private List<Adventurer> adventurers = new List<Adventurer>();
    private List<Quest> quests = new List<Quest>();

    public void IncreaseGold()
    {
        gold.ApplyChange(1);
    }
    
    public void HireAdventurer(Adventurer adv)
    {
        gold.ApplyChange(-adv.worth);
        adv.transform.parent = adventurerList.transform;
        adventurers.Add(adv);
    }

    public void AcceptQuest(Quest q)
    {
        quests.Add(q);
    }
    
    public void SimulateQuests()
    {
        foreach (Quest q in quests)
        {
            if (q.Status == QuestStatus.InProgess)
            {
                int reward = q.Simulate();
                if (reward >= 0)
                {
                    gold.ApplyChange(reward);
                } 
            }
        }
        onQuestStatusChanged.Invoke();
    }

}

public enum GuildRank
{
    Glass,
    Stone,
    Obsidian,
    Iron,
    Steel,
    Bronze,
    Silver,
    Gold,
    Diamond
}
