using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RangedInt
{
    public int minValue;
    public int maxValue;

    public int Value { get => Random.Range(minValue, maxValue+1); }

    public RangedInt(int min, int max)
    {
        this.minValue = min;
        this.maxValue = max;
    }
}
