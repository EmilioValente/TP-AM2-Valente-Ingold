using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestSearchWindow : EditorWindow {

    ScriptableObject _focusQuest;

    string _searchAssetByName;
    List<ScriptableObject> _quests = new List<ScriptableObject>();
    
    [MenuItem("Custom Windows/Quest Creator Window")]
    static void createWindow()
    {
        GetWindow<QuestSearchWindow>().Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Quest search Window", EditorStyles.boldLabel);

        EditorGUILayout.HelpBox("Drag and drop the quest", MessageType.None);
        _focusQuest = (ScriptableObject)EditorGUILayout.ObjectField("Quest to search", _focusQuest, typeof(ScriptableObject), false);

        EditorGUILayout.HelpBox("Search the quest by ID", MessageType.None);
        QuestSearcher();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Search", GUILayout.Height(30), GUILayout.Width(200)))
        {
            if(_focusQuest != null)
            {
                GetWindow<QuestCreatorWindow>().currentQuest = _focusQuest;
                GetWindow<QuestCreatorWindow>().Show();
            }
        }

        if(GUILayout.Button("Create empty quest", GUILayout.Height(30), GUILayout.Width(200)))
        {
            _focusQuest = ScriptableObjectCreator.CreateSO<QuestLayout>();
            GetWindow<QuestCreatorWindow>().currentQuest = _focusQuest;
            GetWindow<QuestCreatorWindow>().Show();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void QuestSearcher()
    {
        var aux = _searchAssetByName;
        _searchAssetByName = EditorGUILayout.TextField("Quest ID", aux);
        string[] folderToSearch = { "Assets/Quests" };
        int i;
        if (aux != _searchAssetByName)
        {
            _quests.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_searchAssetByName, folderToSearch);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]); 
                _quests.Add((ScriptableObject)AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(ScriptableObject))); 
            }
        }
        for (i = _quests.Count - 1; i >= 0; i--)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(_quests[i].ToString());
            if (GUILayout.Button("Select"))
            {
                _focusQuest = _quests[i];
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
