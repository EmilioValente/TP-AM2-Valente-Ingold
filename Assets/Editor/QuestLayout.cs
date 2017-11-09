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
    public string Name;
    public string description;

    public List<string> NameRewardList = new List<string>();
    public List<int> IdRewardList = new List<int>();
    public List<float> AmountRewardList = new List<float>();
    #endregion

}
