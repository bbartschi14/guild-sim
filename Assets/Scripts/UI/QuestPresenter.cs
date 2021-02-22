using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPresenter : MonoBehaviour
{
    public GameObject presentPanelPrefab;
    public void Present(Quest q)
    {
        GameObject panel = Instantiate(presentPanelPrefab, transform);
        panel.transform.position = transform.position;
        PresentQuestPanel presenter = panel.GetComponent<PresentQuestPanel>();
        presenter.FormatPanel(q);
    }
}
