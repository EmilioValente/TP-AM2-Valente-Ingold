using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectCreator {

	public static ScriptableObject CreateSO<T>(string name) where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath("Assets/Quests/" + name + ".asset");
        AssetDatabase.CreateAsset(asset, assetPathAndName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        return asset;
    }
}
