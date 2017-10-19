using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestCreatorWindow : EditorWindow {

    //diccionario que contiene todas las quests creadas. (el int es temporal hay q reemplazarlo x una clase que contenga las opciones de las quests o algo)
    Dictionary<string, int> _allQuests = new Dictionary<string, int>();

    int _questIDInt;
    string _questID;
    int CharacterMaxLvl;
    int CharacterMinLvl;
    characterclass clase;


    public enum characterclass
    {
        paladin,
        warrior,
        wizard
    }

    [MenuItem("Custom Windows/Quest Creator Window")]
    static void createWindow()
    {
        ((QuestCreatorWindow)GetWindow(typeof(QuestCreatorWindow))).Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Quest creator window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        clase = (characterclass)EditorGUILayout.EnumPopup("clase", clase); // pregunto la clase que puede llevar a cabo la quest
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
