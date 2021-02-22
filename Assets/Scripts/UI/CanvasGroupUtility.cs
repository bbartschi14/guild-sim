using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupUtility : MonoBehaviour
{
    public CanvasGroup cg;
    public float activeAlpha;
    private void Start()
    {
        if (cg == null)
        {
            cg = GetComponent<CanvasGroup>();
        }
    }

    public void ToggleAlpha()
    {
        if (cg.alpha == 0f)
        {
            cg.alpha = activeAlpha;
            cg.blocksRaycasts = true;
        }
        else
        {
            cg.alpha = 0f;
            cg.blocksRaycasts = false;

        }
    }
}
