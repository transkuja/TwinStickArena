using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeBetweenTwoMonsters;

    public void Spawn(GameObject _toSpawn)
    {
        Instantiate(_toSpawn, transform);
    }

    IEnumerator SpawnCoroutine()
    {
        yield return 0;
    }

    public int GetSpawnerIndex()
    {
        return transform.GetSiblingIndex();
    }
}
