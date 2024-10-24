using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    public GameObject pointPrefab;
    public float spawnInterval = 1f;
    public float spawnY = 6.6f;
    public float leftMinX = -3.38f;
    public float leftMaxX = -1.5f;
    public float rightMinX = 1.5f;
    public float rightMaxX = 3.38f;
    public int groupSize = 5; 
    public float gapBetweenPoints = 0.5f; 

    private void Start()
    {
        StartCoroutine(SpawnPoints());
    }

    private IEnumerator SpawnPoints()
    {
        while (true)
        {
            if (Random.value > 0.5f)
            {
                SpawnPointGroupLeftHorizontal();
                yield return new WaitForSeconds(spawnInterval);
                SpawnPointGroupRightHorizontal();
            }
            else
            {
                SpawnPointGroupLeftVertical();
                yield return new WaitForSeconds(spawnInterval);
                SpawnPointGroupRightVertical();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private void SpawnPointGroupLeftHorizontal()
    {
        float startX = Random.Range(leftMinX, leftMaxX - (groupSize * gapBetweenPoints));
        for (int i = 0; i < groupSize; i++)
        {
            Vector3 spawnPosition = new Vector3(startX + i * gapBetweenPoints, spawnY, 0f);
            Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void SpawnPointGroupRightHorizontal()
    {
        float startX = Random.Range(rightMinX, rightMaxX - (groupSize * gapBetweenPoints));
        for (int i = 0; i < groupSize; i++)
        {
            Vector3 spawnPosition = new Vector3(startX + i * gapBetweenPoints, spawnY, 0f);
            Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void SpawnPointGroupLeftVertical()
    {
        float startX = Random.Range(leftMinX, leftMaxX); 
        for (int i = 0; i < groupSize; i++)
        {
            Vector3 spawnPosition = new Vector3(startX, spawnY - i * gapBetweenPoints, 0f); 
            Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void SpawnPointGroupRightVertical()
    {
        float startX = Random.Range(rightMinX, rightMaxX); 
        for (int i = 0; i < groupSize; i++)
        {
            Vector3 spawnPosition = new Vector3(startX, spawnY - i * gapBetweenPoints, 0f); 
            Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
        }
    }
}