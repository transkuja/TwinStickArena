using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterGroup
{
    public GameObject monsterPrefab;
    public int count;
}

[System.Serializable]
public class Subwave
{
    public MonsterGroup[] monsterGroups;
    public int[] spawnersIndex;
    public float delayBeforeNext = -1;
    public bool spawnNextWhenPreviousCleared = false;
}

[System.Serializable]
public class WaveSO : ScriptableObject
{
    public Subwave[] subwaves;
}
