using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityToggler : MonoBehaviour
{
    public List<CanvasGroup> canvasGroups;

    public void ToggleActive(int activeIndex)
    {
        for (int i = 0; i < canvasGroups.Count; i++)
        {
            if (i == activeIndex)
            {
                canvasGroups[i].alpha = 1;
                canvasGroups[i].blocksRaycasts = true;
            }
            else
            {
                canvasGroups[i].alpha = 0;
                canvasGroups[i].blocksRaycasts = false;
            }
        }
    }
}
