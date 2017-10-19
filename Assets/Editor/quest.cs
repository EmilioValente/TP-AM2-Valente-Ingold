using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class quest : EditorWindow
{
    int CharacterLvl;
    characterclass clase; 

    [MenuItem("create/ quest")]
    static void Window()
    {
        ((quest)GetWindow(typeof(quest))).Show();
    }

    public enum characterclass
    {
        paladin,
        warrior,
        wizard
    }

    private void OnGUI()
    {
        GUILayout.Label("quest creator", EditorStyles.boldLabel);

       
        CharacterLvl = EditorGUILayout.IntField("nivel", CharacterLvl);
        if (CharacterLvl > 100)
        {
            EditorGUILayout.HelpBox("el nivel no puede pasarse de 100", MessageType.Info);
        }

        clase = (characterclass)EditorGUILayout.EnumPopup("clase", clase);
        EditorGUILayout.BeginHorizontal("Button");
        GUILayout.Label("create");
        EditorGUILayout.EndHorizontal();
    }
}
