using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;
public class PresentQuestPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameField;
    public TMPro.TextMeshProUGUI descField;
    public TMPro.TextMeshProUGUI rewardField;

    public GameObject hireButton;
    public GameObject declineButton;

    public QuestGameEvent onQuestAccept;
    public QuestGameEvent onQuestReject;
    public UnityEvent onQuestStatusChanged;
    public void FormatPanel(Quest q)
    {
        // Set all texts fields
        nameField.text = q.Name;
        descField.text = q.Description;
        rewardField.text = q.Reward.ToString();

        // Configure button delegates for hiring and declining
        Button b = hireButton.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {
            q.Status = QuestStatus.Posted;
            onQuestAccept.Raise(q);
            onQuestStatusChanged.Invoke();
            Destroy(this.gameObject);
        });
        Button db = declineButton.GetComponent<Button>();
        db.onClick.AddListener(delegate ()
        {
            onQuestReject.Raise(q);
            onQuestStatusChanged.Invoke();
            Destroy(this.gameObject);
        });
    }

}
