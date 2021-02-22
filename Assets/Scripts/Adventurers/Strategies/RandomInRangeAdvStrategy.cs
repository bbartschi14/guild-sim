using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Adventurer Strategies/Random In Range")]
public class RandomInRangeAdvStrategy : AdventurerStrategy
{
    public List<string> advNames;
    public int worth;
    [MinMaxRange(1,20)]
    public RangedInt strength = new RangedInt(1,5);
    [MinMaxRange(1, 20)]
    public RangedInt intellect = new RangedInt(1, 5);
    [MinMaxRange(1, 20)]
    public RangedInt dexterity = new RangedInt(1, 5);
    public override void SetAttributes(Adventurer adv)
    {
        adv.AdventurerName = advNames[Random.Range(0,advNames.Count)];
        adv.Strength = strength.Value;
        adv.Intellect = intellect.Value;
        adv.Dexterity = dexterity.Value;
        adv.worth = worth;
    }
}
