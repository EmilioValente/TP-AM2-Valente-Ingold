using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestLogWindow : EditorWindow
{

    string _questName;
    string _questDescription;
    GameObject _itenReward;
    string RewardName;
    int RewardId=0;
    float RewardAmaunt=0; 
    List<string> NameRewardList = new List<string>();
    List<int> IdRewardList = new List<int>();
    List<float> AmauntRewardList = new List<float>();


    void OnGUI()
    {
        GUILayout.Label("Quest log window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        _questName = EditorGUILayout.TextField("Quest Name", _questName);

        EditorGUILayout.BeginVertical();
        GUILayout.Label("Description", EditorStyles.boldLabel);
        _questDescription = EditorGUILayout.TextField("", _questDescription, GUILayout.Height(100));
        GUILayout.Label("recompenza", EditorStyles.boldLabel);
        EditorGUILayout.EndVertical();
        RewardName = EditorGUILayout.TextField("Reward", RewardName);
        RewardId = EditorGUILayout.IntField("Reward Id", RewardId);
        RewardAmaunt = EditorGUILayout.FloatField("Amaunt", RewardAmaunt);
        if (GUILayout.Button("guardar"))
        {

            if (RewardName != null)
            {
                if (!NameRewardList.Contains(RewardName))
                {
                    NameRewardList.Add(RewardName);
                    IdRewardList.Add(RewardId);
                    AmauntRewardList.Add(RewardAmaunt);
                    Debug.Log("guarde");
                }
            }

        }

        GUILayout.Label("Rewards saved", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < RewardName.Length; i++)
        {

            //var RewardsName = RewardName[i];

            //EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 50), RewardsName);

        }

        EditorGUILayout.EndHorizontal();

    }

}

    