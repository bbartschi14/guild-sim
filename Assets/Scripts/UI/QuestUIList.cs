using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIList : MonoBehaviour
{
    public GameObject questPanelPrefab;
    
    public List<QuestPanel> panels;
    public Color panelIdle;
    public Color panelHover;
    public Color panelActive;
    public QuestPanel selectedPanel;
    public Transform container;

    public QuestStatus filterType;
    public void AddQuest(Quest q)
    {
        GameObject panel = Instantiate(questPanelPrefab, container);
        QuestPanel questPanel = panel.GetComponent<QuestPanel>();
        questPanel.quest = q;
        questPanel.FormatPanel();
        
        Subscribe(questPanel);
        Filter(questPanel);
    }

    public void Subscribe(QuestPanel panel)
    {
        if (panels == null)
        {
            panels = new List<QuestPanel>();
        }

        if (!panels.Contains(panel))
        {
            panels.Add(panel);
        }
         
    }
    
    public void OnPanelEnter(QuestPanel panel)
    {
        ResetPanels();
        if (selectedPanel == null || panel != selectedPanel)
        {
            panel.background.color = panelHover;
        }
    }
    
    public void OnPanelExit(QuestPanel panel)
    {
        ResetPanels();
    }
    
    public void OnPanelSelected(QuestPanel panel)
    {
        selectedPanel = panel;
        ResetPanels();
        panel.background.color = panelActive;
        int index = panel.transform.GetSiblingIndex();
    }
    
    public void ResetPanels()
    {
        foreach (QuestPanel p in panels)
        {
            if (selectedPanel != null && p == selectedPanel)  { continue; }
            p.background.color = panelIdle;
        }
    }

    public void ClearSelected()
    {
        selectedPanel = null;
        ResetPanels();
    }

    public void FilterPanels() 
    {
        foreach (QuestPanel panel in panels)
        {
            if (panel.quest.Status != filterType)
            {
                panel.gameObject.SetActive(false);
            }
            else
            {
                panel.gameObject.SetActive(true);
            }
        }
    }

    private void Filter(QuestPanel panel)
    {
        if (panel.quest.Status != filterType)
        {
            panel.gameObject.SetActive(false);
        }
    }

    public void SetFilterType(int i)
    {
        filterType = (QuestStatus) (i + 1);
        FilterPanels();
    }
    
}
