using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestLogWindow : EditorWindow
{
    public QuestLayout currentQuest;

    string RewardName;
    int RewardId=0;
    float RewardAmount=0;
    bool warningMessage = false;
    bool warningMessageAmount = false;

    void OnGUI()
    {
        minSize = new Vector2(400, 450);
        GUILayout.Label("Quest log window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        currentQuest.Name = EditorGUILayout.TextField("Quest Name", currentQuest.Name);
        
        GUILayout.Label("Description");
        currentQuest.description = EditorGUILayout.TextField("", currentQuest.description, GUILayout.Height(100));

        GUILayout.Label("Rewards", EditorStyles.boldLabel);                
        RewardName = EditorGUILayout.TextField("Reward Name", RewardName);
        RewardId = EditorGUILayout.IntField("Reward Id", RewardId);
        RewardAmount = EditorGUILayout.FloatField("Amount", RewardAmount);

        //guardo los parametros de arriba en las listas
        if (GUILayout.Button("Save rewards"))
        {
            if (RewardName != null && RewardName.Length > 0 && RewardAmount>0)
            {
                if (!currentQuest.NameRewardList.Contains(RewardName))
                {
                    currentQuest.NameRewardList.Add(RewardName);
                    currentQuest.IdRewardList.Add(RewardId);
                    currentQuest.AmountRewardList.Add(RewardAmount);
                    warningMessage = false;
                    warningMessageAmount = false;
                    Debug.Log("guarde");
                }else
                {
                    var questIndex = currentQuest.NameRewardList.IndexOf(RewardName);
                    currentQuest.IdRewardList[questIndex] = RewardId;
                    currentQuest.AmountRewardList[questIndex] = RewardAmount;
                    Debug.Log("modifique");
                }
            }
            else if(RewardName == null || RewardName.Length == 0)
            {
                warningMessage = true;
            }
            if(RewardAmount<=0)
            {
                warningMessageAmount = true;
            }
        }
        //Si no ingrso un nombre y apreta guardar le doy un mensaje de error
        if (warningMessage)
        {
            EditorGUILayout.HelpBox("Insert reward name", MessageType.Error);
        }
        if(warningMessageAmount)
        {
            EditorGUILayout.HelpBox("the amount can't be less than 0", MessageType.Error);
        }

        //Mostramos las listas
        GUILayout.Label("Rewards saved:");
        if(currentQuest.NameRewardList.Count == 0)
        {
            EditorGUILayout.HelpBox("No rewards saved", MessageType.None);
        }
        for (int i = 0; i < currentQuest.NameRewardList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 20), currentQuest.NameRewardList[i]);
            EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 20), "ID: " + currentQuest.IdRewardList[i].ToString());
            EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 20), "Amount: " + currentQuest.AmountRewardList[i].ToString());
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                currentQuest.NameRewardList.RemoveAt(i);
                currentQuest.IdRewardList.RemoveAt(i);
                currentQuest.AmountRewardList.RemoveAt(i);
                Repaint();
            }
            EditorGUILayout.EndHorizontal();
        }

    }

}    