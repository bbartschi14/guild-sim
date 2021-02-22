using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStrategy : ScriptableObject
{
    public abstract Quest GenerateQuest();
}

