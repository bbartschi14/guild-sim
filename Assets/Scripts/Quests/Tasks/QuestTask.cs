using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestTask : ScriptableObject
{
    public abstract bool CompleteTask(List<Adventurer> advs);
}

