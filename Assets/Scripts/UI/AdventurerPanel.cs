using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AdventurerPanel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMPro.TextMeshProUGUI nameField;
    private string nameLabel;
    public TMPro.TextMeshProUGUI strengthField;
    private string strengthLabel;

    public TMPro.TextMeshProUGUI intellectField;
    private string intellectLabel;

    public TMPro.TextMeshProUGUI dexterityField;
    private string dexterityLabel;

    public Image background;
    public Adventurer adv;
    public AdventurerUIList advList;

    private void OnEnable()
    {
        if (strengthLabel == null)
        {
            strengthLabel = strengthField.text;
            intellectLabel = intellectField.text;
            dexterityLabel = dexterityField.text;
        }
    }
    public void FormatPanel()
    {
        // Set all texts fields
        if (adv != null)
        {
            nameField.text = adv.AdventurerName;
            strengthField.text = strengthLabel + " " + adv.Strength;
            intellectField.text = intellectLabel + " " + adv.Intellect;
            dexterityField.text = dexterityLabel + " " + adv.Dexterity;
            advList.UpdatePanelStyles();
            
            
        }
        
    }

    public void Updated(int i)
    {
        if (i == this.transform.GetSiblingIndex())
        {
            FormatPanel();
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!adv.isAssigned) advList.OnPanelSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!adv.isAssigned) advList.OnPanelEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!adv.isAssigned) advList.OnPanelExit(this);
    }

    private void Start()
    {
        
        background.color = advList.panelIdle;
        
    }
}
