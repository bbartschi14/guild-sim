using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdventurerStrategy : ScriptableObject
{
    public abstract void SetAttributes(Adventurer adv);
}
