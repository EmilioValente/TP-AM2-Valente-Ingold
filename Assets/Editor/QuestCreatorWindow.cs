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


    void OnGUI()
    {
        GUILayout.Label("Quest creator window", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Currently working on: " + currentQuest.name);
        EditorGUILayout.Space();

        currentQuest.EnemiesAmount = new List<int>();
        currentQuest.EnemiesType = new List<string>();

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
        GUILayout.Label("NPC", EditorStyles.boldLabel);
        currentQuest.IdNPCQuestDealer = EditorGUILayout.IntField("Quest Dealer", currentQuest.IdNPCQuestDealer);

        GUILayout.Label("Enemies", EditorStyles.boldLabel);
        EnemiesType = EditorGUILayout.TextField("Enemie Type", EnemiesType);
        EnemiesAmaount = EditorGUILayout.IntField("Enemies amaunt", EnemiesAmaount);
        if (GUILayout.Button("add enemies"))
        {
            Debug.Log("addenemies");
            if (EnemiesAmaount > 0 && EnemiesType != "")
            {
                if (!currentQuest.EnemiesType.Contains(EnemiesType))
                {
                    currentQuest.EnemiesType.Add(EnemiesType);
                    currentQuest.EnemiesAmount.Add(EnemiesAmaount);
                    EnemiesType = "";
                    EnemiesAmaount = 0;
                    warningMessageType = false;
                    warningMessageAmaount = false;
                    Debug.Log("guarde");

                }
                else
                {
                    var enemiesIndex = currentQuest.EnemiesType.IndexOf(EnemiesType);
                    currentQuest.AmountRewardList[enemiesIndex] = EnemiesAmaount;
                    Debug.Log("cambie");
                    warningMessageType = false;
                    warningMessageAmaount = false;

                }

            }
            if (EnemiesType == null || EnemiesType == "")
            {
                warningMessageType = true;
                Debug.Log("lala");
            }

            if (EnemiesAmaount == 0)
            {
                warningMessageAmaount = true;
                Debug.Log("warning amaount" + warningMessageAmaount + " warning type" + warningMessageType + " enemiestype" + EnemiesType + "     enemie amaount" + EnemiesAmaount);
            }
            if (EnemiesAmaount == 0 && EnemiesType == "")
            {
                warningMessageAmaount = true;
                warningMessageType = true;
                Debug.Log("lala3");
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
            for (int i = 0; i < currentQuest.EnemiesType.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 20), "type", currentQuest.EnemiesType[i]);

                EditorGUI.LabelField(GUILayoutUtility.GetRect(50, 20), "Amount: " + currentQuest.EnemiesAmount[i].ToString());
                EditorGUILayout.EndHorizontal();
            }
        }

    }
}
