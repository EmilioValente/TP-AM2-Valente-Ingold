using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestCreatorWindow : EditorWindow {

    public ScriptableObject currentQuest;

    //diccionario que contiene todas las quests creadas. (el int es temporal hay q reemplazarlo x una clase que contenga las opciones de las quests o algo)
    Dictionary<string, int> _allQuests = new Dictionary<string, int>();

    int _questIDInt;
    string _questID;

    int CharacterMaxLvl=1;
    int CharacterMinLvl=1;
    string clase;

    void OnGUI()
    {
        currentQuest = (ScriptableObject)EditorGUILayout.ObjectField(currentQuest, typeof(ScriptableObject), false);
        GUILayout.Label("Quest creator window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        clase = EditorGUILayout.TextField("clase",clase); // pregunto la clase que puede llevar a cabo la quest
        CharacterMinLvl = EditorGUILayout.IntField("nivel minimo para la quest", CharacterMinLvl); //pido nivel minimo para la mision
        if (CharacterMinLvl < 1)
        {
            EditorGUILayout.HelpBox("el nivel no puede ser menor a 1", MessageType.Info);
        }
        CharacterMaxLvl = EditorGUILayout.IntField("nivel maximo para la quest", CharacterMaxLvl);//pido nivel maximo para la mision
        if (CharacterMaxLvl > 100)
        {
            EditorGUILayout.HelpBox("el nivel no puede pasarse de 100", MessageType.Info);
        }

        if(CharacterMaxLvl-CharacterMinLvl>25)
        {
            EditorGUILayout.HelpBox("no se recomienda que el rango sea muy extenso", MessageType.None);
        }

        //var aa = _allQuests.Keys;

        //_questIDInt = EditorGUILayout.Popup("Quests", _questIDInt, ()_allQuests.Keys)

        _questID = EditorGUILayout.TextField("Quest ID", _questID);

        
        //Creo un boton que me abre una ventana nueva donde se puede editar el quest log
        if(GUILayout.Button("Quest Log"))
        {
            ((QuestLogWindow)GetWindow(typeof(QuestLogWindow))).Show();
        }

        EditorGUILayout.BeginHorizontal("Button");
        GUILayout.Label("create");
        EditorGUILayout.EndHorizontal();
    }
}
