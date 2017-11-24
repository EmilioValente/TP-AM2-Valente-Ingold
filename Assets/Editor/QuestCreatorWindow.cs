using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestCreatorWindow : EditorWindow
{

    public QuestLayout currentQuest;
    int EnemiesAmount;
    string EnemiesType = "";
    bool warningMessageType = false;
    bool warningMessageAmount = false;

    /*
     to do:
     -arreglar nombres de campos para q este todo en un mismo lenguaje y q entre en la label
     -nombre de quest al crearlas(una campo q pida nombre en searcher) y q cambie cuando cambiamos el nombre
     -clampear todos los campos para q no halla valores no posibles
     -mensajes de error q no aparescan todo el tiempo si el valor no es el correcto (si no se puede, vemos q hacemos lo dejamos o lo elimimamos)
     */

    void OnGUI()
    {
        minSize = new Vector2(400, 450);

        GUILayout.Label("Quest creator window", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Currently working on: " + currentQuest.name);
        EditorGUILayout.Space();

        currentQuest.clase = EditorGUILayout.TextField("class", currentQuest.clase); // pregunto la clase que puede llevar a cabo la quest

        currentQuest.minLevel = EditorGUILayout.IntField("min level required", currentQuest.minLevel); //pido nivel minimo para la mision

        if(currentQuest.minLevel<1 )
        {
            currentQuest.minLevel = 1;
        }
        if (currentQuest.maxLevel < 1)
        {
            currentQuest.maxLevel = 1;
        }
        if (currentQuest.minLevel < 1)
        { 
            EditorGUILayout.HelpBox("minLvl can't be less than 1", MessageType.Info);
        }

        currentQuest.maxLevel = EditorGUILayout.IntField("maxLevel ", currentQuest.maxLevel);//pido nivel maximo para la mision

         if (currentQuest.minLevel > currentQuest.maxLevel && currentQuest.maxLevel != 1)
        {
            EditorGUILayout.HelpBox("minLvl can't be higher than maxLvl", MessageType.Error);
        }
        
        //Creo un boton que me abre una ventana nueva donde se puede editar el quest log
        if (GUILayout.Button("Quest Log"))
        {
            GetWindow<QuestLogWindow>().currentQuest = currentQuest;
            ((QuestLogWindow)GetWindow(typeof(QuestLogWindow))).Show();
        }

        //npc
        GUILayout.Label("NPC", EditorStyles.boldLabel);
        currentQuest.IdNPCQuestDealer = EditorGUILayout.IntField("Quest Dealer", currentQuest.IdNPCQuestDealer);

        //enemigos
        GUILayout.Label("Enemies", EditorStyles.boldLabel);
        EnemiesType = EditorGUILayout.TextField("Enemie Type", EnemiesType);
        EnemiesAmount = EditorGUILayout.IntField("Enemies amount", EnemiesAmount);
        if (GUILayout.Button("add enemies"))
        {
            if (EnemiesType != null && EnemiesType.Length>0 && EnemiesAmount > 0)
            {
                warningMessageType = false;
                warningMessageAmount = false;
                if (!currentQuest.listEnemiesType.Contains(EnemiesType))
                {
                    currentQuest.listEnemiesType.Add(EnemiesType);
                    currentQuest.listEnemiesAmount.Add(EnemiesAmount);
                    warningMessageType = false;
                    warningMessageAmount = false;
                }
                else
                {
                    var enemiesIndex = currentQuest.listEnemiesType.IndexOf(EnemiesType);
                    currentQuest.listEnemiesAmount[enemiesIndex] = EnemiesAmount;
                    warningMessageType = false;
                    warningMessageAmount = false;
                }
            }
            if (EnemiesType == null || EnemiesType == "")
            {
                warningMessageType = true;
            }
            if (EnemiesAmount <= 0)
            {
                warningMessageAmount = true;
               
            }
            EnemiesType = "";
            EnemiesAmount = 0;
           

        }
        if (warningMessageAmount)
        {
            EditorGUILayout.HelpBox("Insert a valid enemies amount", MessageType.Error);
        }
        if (warningMessageType)
        {
            EditorGUILayout.HelpBox("Insert enemies type", MessageType.Error);
        }
        GUILayout.Label("Enemies saved");
        if (currentQuest.listEnemiesType.Count == 0)
        {
            EditorGUILayout.HelpBox("No enemies saved", MessageType.None);
        }
        for (int i = 0; i < currentQuest.listEnemiesType.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 20), "type: " + currentQuest.listEnemiesType[i]);
            EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 20), "Amount: " + currentQuest.listEnemiesAmount[i].ToString());
            //boton para eliminar elementos del array
            if(GUILayout.Button("X", GUILayout.Width(20)))
            {
                currentQuest.listEnemiesType.RemoveAt(i);
                currentQuest.listEnemiesAmount.RemoveAt(i);
                Repaint();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
