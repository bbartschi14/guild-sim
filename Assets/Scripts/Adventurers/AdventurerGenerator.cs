using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Adventurer Generator")]
public class AdventurerGenerator : ScriptableObject
{
    public AdventurerStrategy strategy;
    public GameObject advPrefab;
    public Adventurer GenerateAdventurer(AdventurerStrategy strategy)
    {
        GameObject advObject = Instantiate(advPrefab);
        Adventurer adv = advObject.GetComponent<Adventurer>();
        strategy.SetAttributes(adv);

        return adv;
    }

    public Adventurer GenerateAdventurer()
    {
        return GenerateAdventurer(strategy);
    }
}
