using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestSearchWindow : EditorWindow {

    ScriptableObject _focusQuest;

    string _questID;
    string _searchAssetByName;
    List<ScriptableObject> _quests = new List<ScriptableObject>();
    Vector2 _scrollBar;

    [MenuItem("Custom Windows/Quest Creator Window")]
    static void createWindow()
    {
        GetWindow<QuestSearchWindow>().Show();
    }

    void OnGUI()
    {
        minSize = new Vector2(410,350);

        //creador de quests vacias
        EditorGUILayout.LabelField("Create quest", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox("Create an empty quest", MessageType.None);
        _questID = EditorGUILayout.TextField("Quest name", _questID);

        EditorGUILayout.BeginHorizontal();
        GUILayoutUtility.GetRect(1, 1);
        GUILayoutUtility.GetRect(1, 1);
        if (GUILayout.Button("Create empty quest", GUILayout.Height(20), GUILayout.Width(175)))
        {
            _focusQuest = ScriptableObjectCreator.CreateSO<QuestLayout>();
            GetWindow<QuestCreatorWindow>().currentQuest = (QuestLayout)_focusQuest;
            GetWindow<QuestCreatorWindow>().Show();
            Repaint();
        }
        GUILayoutUtility.GetRect(1, 1);
        EditorGUILayout.EndHorizontal();

        //buscador por drageo de objeto
        var aux = _focusQuest;
        EditorGUILayout.LabelField("Quest search Window", EditorStyles.boldLabel);

        EditorGUILayout.HelpBox("Drag and drop the quest", MessageType.None);
        _focusQuest = (ScriptableObject)EditorGUILayout.ObjectField("Quest to search", _focusQuest, typeof(ScriptableObject), false);

        EditorGUILayout.BeginHorizontal();
        GUILayoutUtility.GetRect(1, 1);
        GUILayoutUtility.GetRect(1, 1);
        if (GUILayout.Button("Open selected quest", GUILayout.Height(20), GUILayout.Width(175)))
        {
            if (_focusQuest != null)
            {
                GetWindow<QuestCreatorWindow>().currentQuest = (QuestLayout)_focusQuest;
                GetWindow<QuestCreatorWindow>().Show();
            }
        }
        GUILayoutUtility.GetRect(1, 1);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //buscador de quest por nombre
        EditorGUILayout.HelpBox("Search the quest by name", MessageType.None);
        QuestSearcher();

        //si cambio el target cierro las ventanas de trabajo, y abro el nuevo target
        if(_focusQuest != aux)
        {
            GetWindow<QuestCreatorWindow>().Close();
            GetWindow<QuestLogWindow>().Close();
            GetWindow<QuestCreatorWindow>().currentQuest = (QuestLayout)_focusQuest;
            GetWindow<QuestCreatorWindow>().Show();
        }        
    }

    private void QuestSearcher()
    {
        var aux = _searchAssetByName;
        _searchAssetByName = EditorGUILayout.TextField("Quest name", aux);
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
        _scrollBar = EditorGUILayout.BeginScrollView(_scrollBar, false, true);
        for (i = _quests.Count - 1; i >= 0; i--)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(_quests[i].ToString());
            if (GUILayout.Button("Select"))
            {
                //abro la ventana cuando selecciono
                _focusQuest = _quests[i];
                GetWindow<QuestCreatorWindow>().currentQuest = (QuestLayout)_focusQuest;
                GetWindow<QuestCreatorWindow>().Show();
            }
            //muevo quest a la papelera
            if (GUILayout.Button("X", GUILayout.Width(20)))
            {
                if(_focusQuest == _quests[i])
                {
                    _focusQuest = null;
                }
                AssetDatabase.MoveAssetToTrash(AssetDatabase.GetAssetPath(_quests[i]));
                _quests.RemoveAt(i);
                Repaint();
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();
    }
}
