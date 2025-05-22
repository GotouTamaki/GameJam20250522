using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavwenemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    private int currentWave = 0;
    private int[] enemyCountsParWave = { 5, 10, 15, 20, 30, 35, 40, 45, 50, 60 };

    public void StartNextWave()
    {
        if (currentWave < enemyCountsParWave.Length)
        {
            int count = enemyCountsParWave[currentWave];
            StartCoroutine(SpawnEnemies(count));
            currentWave++;

        }
    }

    IEnumerator SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.7f);
        }
    }
    }