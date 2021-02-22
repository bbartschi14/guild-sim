using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Adventurer Strategies/Default")]
public class DefaultAdventurerStrategy : AdventurerStrategy
{
    public string advName;
    public int strength;
    public int intellect;
    public int dexterity;
    public override void SetAttributes(Adventurer adv)
    {
        adv.AdventurerName = advName;
        adv.Strength = strength;
        adv.Intellect = intellect;
        adv.Dexterity = dexterity;
    }
}
