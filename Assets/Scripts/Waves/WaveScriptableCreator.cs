using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveScriptableCreator
{
    [MenuItem("Assets/Create/Wave Scriptable Object")]
    public static void CreateWaveSO()
    {
        WaveSO asset = ScriptableObject.CreateInstance<WaveSO>();

        AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/Waves/NewWaveSO.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
