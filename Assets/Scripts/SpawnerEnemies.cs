using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;
    public float spawnY = 6.6f;
    public float leftMinX = -3.38f;
    public float leftMaxX = -1.5f;
    public float rightMinX = 1.5f;
    public float rightMaxX = 3.38f;
    public float speedIncrementInterval = 3f;
    public float spawnIntervalDecrease = 0.2f; 
    private float minSpawnInterval = 0.5f;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(IncreaseEnemySpeedOverTime());
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemyLeft();
            yield return new WaitForSeconds(spawnInterval);

            SpawnEnemyRight();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator IncreaseEnemySpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncrementInterval);

            if (spawnInterval > minSpawnInterval)
            {
                spawnInterval -= spawnIntervalDecrease;
                spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval); 
            }
        }
    }

    private void SpawnEnemyLeft()
    {
        float randomX = Random.Range(leftMinX, leftMaxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        GameObject enemy = Instantiate(GetRandomEnemyPrefab(), spawnPosition, Quaternion.identity);
    }

    private void SpawnEnemyRight()
    {
        float randomX = Random.Range(rightMinX, rightMaxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        GameObject enemy = Instantiate(GetRandomEnemyPrefab(), spawnPosition, Quaternion.identity);
    }
    private GameObject GetRandomEnemyPrefab()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[randomIndex];
    }
}