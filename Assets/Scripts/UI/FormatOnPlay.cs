using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormatOnPlay : MonoBehaviour
{
    public TypeToFormat type;
    public bool useCanvasGroup;
    private void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        CanvasGroup cg = GetComponent<CanvasGroup>();

        switch (type)
        {
            case TypeToFormat.TopBottom:
                rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
                rt.offsetMin= new Vector2(rt.offsetMin.x, 0);
                if (useCanvasGroup)
                {
                    cg.alpha = 0;
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case TypeToFormat.Position:
                rt.anchoredPosition = new Vector3(0, 0,0);
                if (useCanvasGroup)
                {
                    cg.alpha = 0;
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
                break;
            default:
                Debug.Log("Formatting type not set");
                break;
        }
                
        
    }
}

public enum TypeToFormat
{
    TopBottom,
    Position
}