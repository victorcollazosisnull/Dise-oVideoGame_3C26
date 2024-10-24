using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; 
    public float spawnY = 6.6f;
    public float leftMinX = -3.38f;
    public float leftMaxX = -1.5f;  
    public float rightMinX = 1.5f;   
    public float rightMaxX = 3.38f;  

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
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
    private void SpawnEnemyLeft()
    {
        float randomX = Random.Range(leftMinX, leftMaxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnEnemyRight()
    {
        float randomX = Random.Range(rightMinX, rightMaxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}