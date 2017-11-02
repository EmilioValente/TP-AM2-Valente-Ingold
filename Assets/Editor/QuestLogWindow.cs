using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestLogWindow : EditorWindow {

    string _questName;
    string _questDescription;
    int _goldReward;
    int ExpReward;
    GameObject _itenReward;

    void OnGUI()
    {
        GUILayout.Label("Quest log window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        _questName = EditorGUILayout.TextField("Quest Name", _questName);

        
        EditorGUILayout.BeginVertical();
        GUILayout.Label("Description", EditorStyles.boldLabel);
        _questDescription = EditorGUILayout.TextField("", _questDescription,GUILayout.Height(100));
        GUILayout.Label("recompenza", EditorStyles.boldLabel);
        EditorGUILayout.IntField("gold",_goldReward);
        EditorGUILayout.IntField("Exp", _goldReward);
        //EditorGUILayout.ObjectField(null, _itenReward);
        EditorGUILayout.EndVertical();



    }
	
}
