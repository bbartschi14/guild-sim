using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentAdventurerPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameField;
    public TMPro.TextMeshProUGUI strengthField;
    public TMPro.TextMeshProUGUI intellectField;
    public TMPro.TextMeshProUGUI dexterityField;
    public TMPro.TextMeshProUGUI hireField;

    public GameObject hireButton;
    public GameObject declineButton;

    public AdventurerGameEvent onAdventurerHire;
    public IntVariable guildGold;

    public void FormatPanel(Adventurer adv)
    {
        // Set all texts fields
        nameField.text = adv.AdventurerName;
        strengthField.text += " " + adv.Strength;
        intellectField.text += " " + adv.Intellect;
        dexterityField.text += " " + adv.Dexterity;
        hireField.text += " (" + adv.worth + ")";

        // Configure button delegates for hiring and declining
        Button b = hireButton.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {
            onAdventurerHire.Raise(adv);
            Destroy(this.gameObject);
        });
        if (guildGold.Value < adv.worth)
        {
            b.interactable = false;
        }
        Button db = declineButton.GetComponent<Button>();
        db.onClick.AddListener(delegate ()
        {
            Destroy(this.gameObject);
        });
    }

}
