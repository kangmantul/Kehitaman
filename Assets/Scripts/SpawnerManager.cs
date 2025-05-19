using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public float spawnDistance = 2f;
    private float lastSpawnY;

    void Start()
    {
        lastSpawnY = player.position.y;
    }

    void Update()
    {
        if (player.position.y > lastSpawnY - spawnDistance)
        {
            SpawnNextObs();
            lastSpawnY += spawnDistance;
        }
    }

    void SpawnNextObs()
    {
        float randomX = Random.Range(-2f, 2f);
        Vector2 spawnPos = new Vector2(randomX, lastSpawnY + spawnDistance);
        Instantiate(platformPrefab, spawnPos, Quaternion.identity);
    }
}
