using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectCreator {

	public static ScriptableObject CreateSO<T>() where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();
        //arreglar: ID como nombre de quest
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Quests/" + typeof(T).ToString() + ".asset");
        AssetDatabase.CreateAsset(asset, assetPathAndName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        return asset;
    }
}
