using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerUIList : MonoBehaviour
{
    public GameObject advPanelPrefab;
    public bool selectMultiple;
    public Transform container;

    
    public List<AdventurerPanel> panels;
    public Color panelIdle;
    public Color panelHover;
    public Color panelActive;
    public Color panelInactive;
    public List<AdventurerPanel> selectedPanels;

    public void AddAdventurer(Adventurer adv)
    {
        GameObject panel = Instantiate(advPanelPrefab, container.transform);
        AdventurerPanel advPanel = panel.GetComponent<AdventurerPanel>();
        advPanel.adv = adv;
        advPanel.FormatPanel();
        
        Subscribe(advPanel);
    }
    public List<Adventurer> GetSelectedAdventurers()
    {
        List<Adventurer> advs = new List<Adventurer>();
        foreach (AdventurerPanel panel in selectedPanels)
        {
            advs.Add(panel.adv);
        }
        return advs;
    }
    
    public void Subscribe(AdventurerPanel panel)
    {
        if (panels == null)
        {
            panels = new List<AdventurerPanel>();
        }

        if (!panels.Contains(panel))
        {
            panels.Add(panel);
        }
         
    }
    
    public void OnPanelEnter(AdventurerPanel panel)
    {
        ResetPanels();
        if (selectedPanels == null || !selectedPanels.Contains(panel))
        {
            panel.background.color = panelHover;
        }
    }
    
    public void OnPanelExit(AdventurerPanel panel)
    {
        ResetPanels();
    }
    
    public void OnPanelSelected(AdventurerPanel panel)
    {
        if (!selectedPanels.Contains(panel))
        {
            selectedPanels.Add(panel);
            panel.background.color = panelActive;
        }
        else
        {
            selectedPanels.Remove(panel);
            panel.background.color = panelIdle;
        }
    }
    
    public void ResetPanels()
    {
        foreach (AdventurerPanel p in panels)
        {
            if (selectedPanels == null || selectedPanels.Contains(p) || p.adv.isAssigned)  { continue; }
            p.background.color = panelIdle;
        }
    }

    public void FullReset()
    {
        selectedPanels = new List<AdventurerPanel>();
        foreach (AdventurerPanel p in panels)
        {
            p.FormatPanel();
            if (p.adv.isAssigned) p.background.color = panelInactive;
            else
            {
                p.background.color = panelIdle;
            }

        }
    }

    public void UpdatePanelStyles()
    {
        foreach (AdventurerPanel p in panels)
        {
            if (p.adv.isAssigned) p.background.color = panelInactive;
            else if (selectedPanels.Contains(p))
            {
                p.background.color = panelActive;
            }
            else
            {
                p.background.color = panelIdle;
            }

        }
    }
    
}
