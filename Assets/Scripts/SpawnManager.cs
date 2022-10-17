using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    private float spawnRangeX = 8.4f;
    private float spawnRangeY = 4.52f;
    private int numberOfEnemies = 5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(numberOfEnemies);
    }

    void SpawnEnemies(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition(), enemyPrefab[randomEnemy].transform.rotation);
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 randomPos = new Vector2(spawnX, spawnY);

        return randomPos;
    }
}
