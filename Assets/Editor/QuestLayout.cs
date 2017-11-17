using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLayout : ScriptableObject
{

    public int questID;

    #region QuestCreator Variables
    public int minLevel;
    public int maxLevel;
    public string clase;
    public List<string> listEnemiesType = new List<string>();
    public List<int> listEnemiesAmount = new List<int>();
    public int IdNPCQuestDealer;
    #endregion

    #region QuestLog Variables
    public string Name;
    public string description;

    public List<string> NameRewardList = new List<string>();
    public List<int> IdRewardList = new List<int>();
    public List<float> AmountRewardList = new List<float>();
    #endregion
    /* 

     public List<lala> states = new List<lala>();

   
    }

    public class lala
    {
        #region QuestCreator Variables
        public int minLevel;
    public int maxLevel;
    public string clase;
    public int IdNPCQuestDealer;

    public List<string> EnemiesType;
    public List<int> EnemiesAmount;
    #endregion

    #region QuestLog Variables
    public string Name;
    public string description;

    public List<string> NameRewardList;
    public List<int> IdRewardList;
    public List<float> AmountRewardList;
    #endregion
}
      */
}
