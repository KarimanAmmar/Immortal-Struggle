using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestsListManager))]

public class QuestsListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        QuestsListManager quests = (QuestsListManager)target;

        //Quests List Editor
        GUILayout.Label("Quests List:");

        quests.QuestCompleted = EditorGUILayout.ObjectField("Quest Completed", quests.QuestCompleted, typeof(GameEvent), false) as GameEvent;
        EditorGUILayout.Space();

        GUILayout.Label("Quests List:");

        for (int i = 0; i < quests.Quests.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            quests.Quests[i] = (Quest)EditorGUILayout.ObjectField("Quest " + (i + 1), quests.Quests[i],
                typeof(Objective), false);

            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.Space();

        if (GUILayout.Button("Add Quest/Event"))
        {
            quests.Quests.Add(null);
        }
        EditorGUILayout.Space();

        if (GUILayout.Button("Remove Quest/Event") && quests.Quests.Count > 0)
        {
            quests.Quests.RemoveAt(quests.Quests.Count - 1);
        }
    }
}