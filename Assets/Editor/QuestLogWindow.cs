using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestLogWindow : EditorWindow {

    string _questName;
    string _questDescription;
    GameObject _itenReward;
    string RewardName;
    int RewardId;
    Dictionary<string, int> reward;

    void OnGUI()
    {
        GUILayout.Label("Quest log window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        _questName = EditorGUILayout.TextField("Quest Name", _questName);

        
        EditorGUILayout.BeginVertical();
        GUILayout.Label("Description", EditorStyles.boldLabel);
        _questDescription = EditorGUILayout.TextField("", _questDescription,GUILayout.Height(100));
        GUILayout.Label("recompenza", EditorStyles.boldLabel);
        EditorGUILayout.EndVertical();
        RewardName = EditorGUILayout.TextField("Reward", RewardName);
        RewardId = EditorGUILayout.IntField("Reward Id", RewardId);
        if (GUILayout.Button("guardar"))
        reward.Add(RewardName, RewardId);

        foreach (var item in reward)
        {
            EditorGUILayout.BeginHorizontal();

            //GUILayout.Label(, EditorStyles.label);
            EditorGUILayout.EndHorizontal();

        }
        
        

    }
	
}
