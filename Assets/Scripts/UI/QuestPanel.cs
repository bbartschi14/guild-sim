using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestPanel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMPro.TextMeshProUGUI nameField;
    public TMPro.TextMeshProUGUI descField;
    public TMPro.TextMeshProUGUI rewardField;
    public Quest quest;
    public Image background;
    public QuestUIList questList;
    public QuestGameEvent onQuestSelected;
    public void FormatPanel()
    {
        // Set all texts fields
        if (quest != null)
        {
            nameField.text = quest.Name;
            descField.text = quest.Description;
            rewardField.text = quest.Reward.ToString();
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        questList.OnPanelSelected(this);
        onQuestSelected.Raise(quest);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        questList.OnPanelEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        questList.OnPanelExit(this);
    }

    private void Start()
    {
        background.color = questList.panelIdle;
    }
}
