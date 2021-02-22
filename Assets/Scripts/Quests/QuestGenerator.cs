using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Quests/Quest Generator")]

public class QuestGenerator : ScriptableObject
{
    public QuestStrategy strategy;
    public Quest GenerateQuest(QuestStrategy strategy)
    {
        return strategy.GenerateQuest();
    }

    public Quest GenerateQuest()
    {
        return GenerateQuest(strategy);
    }
}
