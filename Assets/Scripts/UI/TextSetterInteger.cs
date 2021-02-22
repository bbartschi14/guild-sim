using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSetterInteger : MonoBehaviour
{
    public IntVariable intVariable;

    public TMPro.TextMeshProUGUI textField;

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        textField.text = intVariable.Value.ToString();
    }
}
