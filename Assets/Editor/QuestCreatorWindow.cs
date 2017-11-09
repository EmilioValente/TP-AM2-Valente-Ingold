using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestCreatorWindow : EditorWindow {

    public QuestLayout currentQuest;

    void OnGUI()
    {
        GUILayout.Label("Quest creator window", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Currently working on: " + currentQuest.name);
        EditorGUILayout.Space();

        currentQuest.clase = EditorGUILayout.TextField("clase",currentQuest.clase); // pregunto la clase que puede llevar a cabo la quest

        currentQuest.minLevel = EditorGUILayout.IntField("nivel minimo para la quest", currentQuest.minLevel); //pido nivel minimo para la mision
        if (currentQuest.minLevel <= 1)
        {
            currentQuest.minLevel = 1;
            EditorGUILayout.HelpBox("el nivel no puede ser menor a 1", MessageType.Info);
        }
        else if (currentQuest.minLevel >= currentQuest.maxLevel)
        {
            currentQuest.minLevel = currentQuest.maxLevel;
        }

        currentQuest.maxLevel = EditorGUILayout.IntField("nivel maximo para la quest", currentQuest.maxLevel);//pido nivel maximo para la mision
        if (currentQuest.maxLevel >= 100)
        {
            currentQuest.maxLevel = 100;
            EditorGUILayout.HelpBox("el nivel no puede pasarse de 100", MessageType.Info);
        }

        if (currentQuest.maxLevel - currentQuest.minLevel > 25)
        {
            EditorGUILayout.HelpBox("no se recomienda que el rango sea muy extenso", MessageType.None);
        }
        
        //Creo un boton que me abre una ventana nueva donde se puede editar el quest log
        if(GUILayout.Button("Quest Log"))
        {
            GetWindow<QuestLogWindow>().currentQuest = currentQuest;
            GetWindow<QuestLogWindow>().Show();
        }

        EditorGUILayout.BeginHorizontal("Button");
        GUILayout.Label("create");
        EditorGUILayout.EndHorizontal();
    }
}
