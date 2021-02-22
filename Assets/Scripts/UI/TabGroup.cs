using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Color tabIdle;
    public Color tabHover;
    public Color tabActive;
    public TabButton selectedTab;
    //public List<CanvasGroup> objectsToSwap;
    public UnityEvent<int> onSelected;
    //public UnityEvent<int> onNotSelected;

    private void Start()
    {
        ResetTabs();
        selectedTab.background.color = tabActive;

    }
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        if (!tabButtons.Contains(button)) tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        onSelected.Invoke(index);
        /*for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                onSelected.Invoke(objectsToSwap[i]);
                //objectsToSwap[i].alpha = 1;
                //objectsToSwap[i].blocksRaycasts = true;

            } else
            {
                onNotSelected.Invoke(objectsToSwap[i]);
                //objectsToSwap[i].alpha = 0;
                //objectsToSwap[i].blocksRaycasts = false;

            }
        }*/
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)  { continue; }
            button.background.color = tabIdle;
        }
    }
}
