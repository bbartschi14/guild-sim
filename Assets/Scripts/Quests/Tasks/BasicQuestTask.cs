using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Quests/Tasks/Basic")]

/*
 * Basic task checks if a value of any adventurer meets the req
 */
public class BasicQuestTask : QuestTask
{
    public Stat stat;
    public int value;
    public override bool CompleteTask(List<Adventurer> advs)
    {
        foreach (Adventurer adv in advs)
        {
            if (adv.GetStat(stat) >= value)
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        string output = "Check that " + stat + " is greater than " + value;
        return output;
    }
}
