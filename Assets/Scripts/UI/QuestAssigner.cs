using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestAssigner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameField;
    public TMPro.TextMeshProUGUI descField;
    public TMPro.TextMeshProUGUI rewardField;
    public Quest quest;
    public AdventurerUIList advList;
    public UnityEvent<Quest> onPostedQuestSelected;
    public void FormatPanel(Quest q)
    {
        quest = q;
        // Set all texts fields
        if (quest != null)
        {
            nameField.text = quest.Name;
            descField.text = quest.Description;
            rewardField.text = quest.Reward.ToString();
        }
        
    }

    public void AssignAdventurers()
    {
        quest.AssignAdventurers(advList.GetSelectedAdventurers());
        quest.Status = QuestStatus.InProgess;
    }

    public void IsQuestPosted(Quest q)
    {
        if (q.Status == QuestStatus.Posted)
        {
            onPostedQuestSelected.Invoke(q);
        }
    }
}
