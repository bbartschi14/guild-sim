using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GuildManager))]
public class GuildManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GuildManager guild = (GuildManager)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Increase Gold"))
        {
            guild.IncreaseGold();
        }

    }
}