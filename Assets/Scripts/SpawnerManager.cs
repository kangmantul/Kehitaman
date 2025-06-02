using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject[] obstaclePrefabs;
    public GameObject lightPrefab;

    public Transform player;

    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float minYGap = 1.5f;
    public float maxYGap = 3f;
    public float obstacleChance = 0.3f;
    public float lightChance = 0.7f;

    private float nextSpawnY;
    private float lastX;

    void Start()
    {
        nextSpawnY = player.position.y;

        for (int i = 0; i < 10; i++)
        {
            SpawnNext();
        }
    }

    void Update()
    {
        if (player.position.y + 10f > nextSpawnY)
        {
            SpawnNext();
        }
    }

    void SpawnNext()
    {
        float randomX;

        do
        {
            randomX = Random.Range(minX, maxX);
        } while (Mathf.Abs(randomX - lastX) < 0.5f);

        lastX = randomX;

        float yGap = Mathf.Lerp(minYGap, maxYGap, Random.value * Random.value);
        nextSpawnY += yGap;

        Vector2 spawnPos = new Vector2(randomX, nextSpawnY);

        GameObject platform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        platform.tag = "Platform";

        if (obstaclePrefabs.Length > 0 && Random.value < obstacleChance)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Vector3 obstaclePos = spawnPos + Vector2.up * 0.5f;
            GameObject obs = Instantiate(obstaclePrefabs[index], obstaclePos, Quaternion.identity);
            obs.tag = "Obstacle";
        }

        if (lightPrefab != null && Random.value < lightChance)
        {
            Vector3 lightPos = spawnPos + Vector2.up * 2f;
            Instantiate(lightPrefab, lightPos, Quaternion.identity);
        }
    }
}
