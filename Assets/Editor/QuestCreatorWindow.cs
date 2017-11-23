using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuestCreatorWindow : EditorWindow
{

    public QuestLayout currentQuest;
    int EnemiesAmaount;
    string EnemiesType = "";
    bool warningMessageType = false;
    bool warningMessageAmaount = false;

    /*
     to do:
     -una x para eliminar cosas de los array de rewards
     -arreglar nombres de campos para q este todo en un mismo lenguaje y q entre en la label
     -nombre de quest al crearlas(una campo q pida nombre en searcher) y q cambie cuando cambiamos el nombre
     -clampear todos los campos para q no halla valores no posibles
     -mensajes de error q no aparescan todo el tiempo si el valor no es el correcto (si no se puede, no poner mensaje xq son medio molestos)
     */

    void OnGUI()
    {
        minSize = new Vector2(400, 450);

        GUILayout.Label("Quest creator window", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Currently working on: " + currentQuest.name);
        EditorGUILayout.Space();

        currentQuest.clase = EditorGUILayout.TextField("clase", currentQuest.clase); // pregunto la clase que puede llevar a cabo la quest

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
        EnemiesAmaount = EditorGUILayout.IntField("Enemies amaunt", EnemiesAmaount);
        if (GUILayout.Button("add enemies"))
        {
            if (EnemiesType != null && EnemiesType.Length>0)
            {
                warningMessageType = false;
                warningMessageAmaount = false;
                if (!currentQuest.listEnemiesType.Contains(EnemiesType))
                {
                    currentQuest.listEnemiesType.Add(EnemiesType);
                    currentQuest.listEnemiesAmount.Add(EnemiesAmaount);
                    warningMessageType = false;
                    warningMessageAmaount = false;
                }
                else
                {
                    var enemiesIndex = currentQuest.listEnemiesType.IndexOf(EnemiesType);
                    currentQuest.listEnemiesAmount[enemiesIndex] = EnemiesAmaount;
                    warningMessageType = false;
                    warningMessageAmaount = false;
                }
            }
            if (EnemiesType == null || EnemiesType == "")
            {
                warningMessageType = true;
            }
            if (EnemiesAmaount == 0)
            {
                warningMessageAmaount = true;
                Debug.Log("warning amaount" + warningMessageAmaount + " warning type" + warningMessageType + " enemiestype" + EnemiesType + "     enemie amaount" + EnemiesAmaount);
            }
            EnemiesType = "";
            EnemiesAmaount = 0;
            Repaint();

        }
        if (warningMessageAmaount)
        {
            EditorGUILayout.HelpBox("Insert a valid enemies amaount", MessageType.Error);
        }
        if (warningMessageType)
        {
            EditorGUILayout.HelpBox("Insert enemies type", MessageType.Error);
        }
        GUILayout.Label("Enemies saved");
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
