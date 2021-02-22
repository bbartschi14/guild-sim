using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Adventurer : MonoBehaviour
{
    private string adventurerName;
    public string AdventurerName { get => adventurerName; set { adventurerName = value; NameChanged(); } }

    /* Stats */
    public int strength;
    public int Strength { get => strength; set { strength = value; StatChanged(); } }
    public int intellect;
    public int Intellect { get => intellect; set { intellect = value; StatChanged(); } }
    public int dexterity;
    public int Dexterity { get => dexterity; set { dexterity = value; StatChanged(); } }
    /* ----- */

    public int worth;
    public bool isAssigned = false;

    public IntGameEvent onUpdateEvent;

    public void SetAssigned(bool b)
    {
        isAssigned = b;
        StatChanged();
    }
    private void NameChanged()
    {
        name = adventurerName;
    }

    private void StatChanged()
    {
        onUpdateEvent.Raise(this.transform.GetSiblingIndex());
    }

    public int GetStat(Stat stat)
    {
        switch(stat)
        {
            case Stat.Strength:
                return Strength;
            case Stat.Intellect:
                return Intellect;
            case Stat.Dexterity:
                return Dexterity;
            default:
                Debug.Log("Stat is not handled");
                return -1;
        } 
    }

}

public enum Stat
{
    Strength,
    Intellect,
    Dexterity
}


