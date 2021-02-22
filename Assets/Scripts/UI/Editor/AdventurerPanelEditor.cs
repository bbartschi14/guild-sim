using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AdventurerPanel))]
public class AdventurerPanelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AdventurerPanel panel = (AdventurerPanel)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Test Stat Change (Strength)"))
        {
            panel.adv.Strength = Random.Range(0,10);
        }

    }
}
