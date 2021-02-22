using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Quests/Strategies/Simple")]
public class SimpleQuestStrategy : QuestStrategy
{
    public string questName;
    public GuildRank rank;
    public string description;
    public int reward;
    public int downPayment;
    public int expectedLength;
    public int timeLimit;
    public int travelTime;
    public List<QuestTask> questTasks;

    public override Quest GenerateQuest()
    {
        return new Quest(questName, description, rank, questTasks, 
                         QuestStatus.Offered, reward, downPayment, 
                         expectedLength, timeLimit, travelTime);
    }
}
