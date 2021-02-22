using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxRangeAttribute : PropertyAttribute
{
    public int min;
    public int max;

    public MinMaxRangeAttribute(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
}
