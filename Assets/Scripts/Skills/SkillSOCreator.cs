using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkillSOCreator
{
    [MenuItem("Assets/Create/Skill Object")]
    public static void CreateSkillSO()
    {
        SkillSO asset = ScriptableObject.CreateInstance<SkillSO>();

        AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/Waves/NewSkillSO.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
