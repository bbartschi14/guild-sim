using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(WorldManager))]
public class WorldManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        WorldManager world = (WorldManager)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Advance Time"))
        {
            world.AdvanceTime();
        }
        if (GUILayout.Button("Present Adventurer"))
        {
            world.PresentNewAdventurer();
        }
        if (GUILayout.Button("Present Quest"))
        {
            world.PresentNewQuest();
        }
        if (GUILayout.Button("Spawn Client"))
        {
            world.SpawnClient();
        }
    }
}
