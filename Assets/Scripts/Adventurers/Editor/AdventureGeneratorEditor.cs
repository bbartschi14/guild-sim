using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AdventurerGenerator))]
public class AdventureGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AdventurerGenerator gen = (AdventurerGenerator)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Generate Adventurer"))
        {
            gen.GenerateAdventurer(gen.strategy);
        }

    }
}

