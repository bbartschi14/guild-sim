using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerPresenter : MonoBehaviour
{
    public GameObject presentPanelPrefab;
    public void Present(Adventurer adv)
    {
        GameObject panel = Instantiate(presentPanelPrefab, transform);
        panel.transform.position = transform.position;
        PresentAdventurerPanel presenter = panel.GetComponent<PresentAdventurerPanel>();
        presenter.FormatPanel(adv);
    }
}
