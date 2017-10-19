using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestCreatorWindow : EditorWindow {

    //diccionario que contiene todas las quests creadas. (el int es temporal hay q reemplazarlo x una clase que contenga las opciones de las quests o algo)
    Dictionary<string, int> _allQuests = new Dictionary<string, int>();

    int _questIDInt;
    string _questID;
	
    [MenuItem("Custom Windows/Quest Creator Window")]
    static void createWindow()
    {
        ((QuestCreatorWindow)GetWindow(typeof(QuestCreatorWindow))).Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Quest creator window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        //var aa = _allQuests.Keys;

        //_questIDInt = EditorGUILayout.Popup("Quests", _questIDInt, ()_allQuests.Keys)

        _questID = EditorGUILayout.TextField("Quest ID", _questID);

        
        //Creo un boton que me abre una ventana nueva donde se puede editar el quest log
        if(GUILayout.Button("Quest Log"))
        {
            ((QuestLogWindow)GetWindow(typeof(QuestLogWindow))).Show();
        }
    }
}
