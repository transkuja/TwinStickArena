using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersHandler : MonoBehaviour
{
    [SerializeField] WaveSO currentWave;

    private void Start()
    {
        if (currentWave != null)
            StartWave();
    }

    public void StartWave()
    {
        StartCoroutine(WaveHandler());
    }

    IEnumerator WaveHandler()
    {
        // Subwaves options not working for now, testing with an uniform wave
        for (int i = 0; i < currentWave.subwaves.Length; i++) 
        {
            for (int j = 0; j < currentWave.subwaves[i].monsterGroups.Length; j++)
            {
                int currentGroupSpawned = 0;
                while (currentGroupSpawned != currentWave.subwaves[i].monsterGroups[j].count)
                {
                    for (int k = 0; k < currentWave.subwaves[i].spawnersIndex.Length; k++)
                    {
                        transform.GetChild(currentWave.subwaves[i].spawnersIndex[k]).GetComponent<Spawner>().Spawn(currentWave.subwaves[i].monsterGroups[j].monsterPrefab);
                        currentGroupSpawned++;

                        yield return new WaitForSeconds(currentWave.subwaves[i].delayBeforeNextMob);
                        if (currentGroupSpawned == currentWave.subwaves[i].monsterGroups[j].count)
                            break;
                    }
                }
            }
        }
    }
}
