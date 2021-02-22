using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdater : MonoBehaviour
{
    public RectTransform rt;
    private Vector2 pos0;
    void Start()
    {
        pos0 = rt.anchoredPosition;
    }

    public void SetPositionToOrigin()
    {
        rt.anchoredPosition = Vector2.zero;
    }

    public void ResetPosition()
    {
        rt.anchoredPosition = pos0;
    }
    

    
}
