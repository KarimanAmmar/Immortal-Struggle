using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Quest quest = (Quest)target;

        quest.questName = EditorGUILayout.TextField("Quest Name", quest.questName);
        //Complete Event 
        GUILayout.Label("Complete Event:");

        quest.questsEvent = EditorGUILayout.ObjectField("Quests Event", quest.questsEvent, typeof(GameEvent), false) as GameEvent;
        EditorGUILayout.Space();

        // Objectives and Events
        GUILayout.Label("Objectives and Events:");

        for (int i = 0; i < quest.objectives.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            quest.objectives[i] = (Objective)EditorGUILayout.ObjectField("Objective " + (i +1), quest.objectives[i],
                typeof(Objective), false);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            quest.questObjEvent[i] = (GameEvent)EditorGUILayout.ObjectField("Event " + ( i +1), quest.questObjEvent[i],
                typeof(GameEvent), false);

            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.Space();

        if (GUILayout.Button("Add Objective/Event"))
        {
            quest.objectives.Add(null);
            quest.questObjEvent.Add(null);
        }
        EditorGUILayout.Space();

        if (GUILayout.Button("Remove Objective/Event") && quest.objectives.Count > 0)
        {
            quest.objectives.RemoveAt(quest.objectives.Count - 1);
            quest.questObjEvent.RemoveAt(quest.questObjEvent.Count - 1);
        }

        // Quest Parameters
        //EditorGUILayout.Space();
        //EditorGUILayout.LabelField("Quest Parameters", EditorStyles.boldLabel);
        //quest.currentObj = EditorGUILayout.IntField("Current Quest", quest.currentObj);
        //quest.Done = EditorGUILayout.Toggle("Quest Completed", quest.Done);

        EditorUtility.SetDirty(quest);
    }
}