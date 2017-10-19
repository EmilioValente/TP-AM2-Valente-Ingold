using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class quest : EditorWindow
{
    int CharacterLvl;

    [MenuItem("create/ quest")]
    static void Window()
    {
        ((quest)GetWindow(typeof(quest))).Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("quest creator", EditorStyles.boldLabel);

        CharacterLvl = EditorGUILayout.IntField("nivel", CharacterLvl);
    }
}
