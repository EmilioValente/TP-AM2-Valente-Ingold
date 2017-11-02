using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestSearchWindow : EditorWindow {
    
    string _searchAssetByName;
    List<Object> _assets = new List<Object>();

    [MenuItem("Custom Windows/Quest Creator Window")]
    static void createWindow()
    {
        ((QuestSearchWindow)GetWindow(typeof(QuestSearchWindow))).Show();
    }

    void OnGUI()
    {

        PrefabSearcher();
        if (GUILayout.Button("Search"))
        {

            //((QuestCreatorWindow)GetWindow(typeof(QuestCreatorWindow))).Show();
        }
    }

    private void PrefabSearcher()
    {
        EditorGUILayout.LabelField("Quest Searcher", EditorStyles.boldLabel);
        var aux = _searchAssetByName;
        _searchAssetByName = EditorGUILayout.TextField("Quest ID", aux);
        string[] folderToSearch = { "Assets/Quests" };
        int i;
        if (aux != _searchAssetByName)
        {
            _assets.Clear();
            string[] allPaths = AssetDatabase.FindAssets(_searchAssetByName, folderToSearch);
            for (i = allPaths.Length - 1; i >= 0; i--)
            {
                allPaths[i] = AssetDatabase.GUIDToAssetPath(allPaths[i]); 
                _assets.Add(AssetDatabase.LoadAssetAtPath(allPaths[i], typeof(Object))); 
            }
        }
        for (i = _assets.Count - 1; i >= 0; i--)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(_assets[i].ToString());
            if (GUILayout.Button("Select"))
            {

            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
