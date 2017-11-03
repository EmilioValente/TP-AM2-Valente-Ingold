using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLayout : ScriptableObject {

    public int questID;

    #region QuestCreator Variables
    public int minLevel;
    public int maxLevel;
    public string clase;
    #endregion
    
    #region QuestLog Variables
    public string questName;
    public string questDescription;
    public Dictionary<string, int> rewards;
    public string rewardName;
    public int rewardID;
    #endregion

}
