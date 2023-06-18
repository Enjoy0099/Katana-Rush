using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spikePrefab, swingingObstaclePrefab, wizardPrefab;

    [SerializeField]
    private GameObject[] rotatingObstaclePrefabs;

    [SerializeField] private float spikeYPos = -0.74f;

    [SerializeField] private float wizardYPos = -0.68f;

    [SerializeField]
    private float rotatingObstacleMinY = -0.69f, rotatingObstacleMaxY = -0.04f;

    [SerializeField]
    private float swingObstacleMinY = 0f, swingObstacleMaxY = 0.4f;

    [SerializeField]
    private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;

    private float spawnWaitTime;

    private int obstacleTypesCount = 4;

    private int obstacleToSpawn;

    private Camera mainCam;

    private Vector3 obstacleSpawnPos = Vector3.zero;

    private GameObject newObstacle;

    [SerializeField] private GameObject healthPrefab;

    [SerializeField]
    private float minHealthY = -0.72f, maxHealthY = -0.2f;

    private Vector3 healthSpawnPos = Vector3.zero;

    [SerializeField] private int healthSpawnProbability = 7;
    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        HandleObstacleSpawning();
    }
    void HandleObstacleSpawning()
    {
        if(Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
            SpawnObstacle();
            SpawnHealth();
        }
    }

    void SpawnObstacle()
    {
        obstacleToSpawn = Random.Range(0, obstacleTypesCount);

        obstacleSpawnPos.x = mainCam.transform.position.x + 3f;

        switch (obstacleToSpawn)
        {
            case 0:
                newObstacle = Instantiate(spikePrefab);
                obstacleSpawnPos.y = spikeYPos;
                break;

            case 1:
                newObstacle = Instantiate(swingingObstaclePrefab);
                obstacleSpawnPos.y = Random.Range(swingObstacleMinY, swingObstacleMaxY);
                break;

            case 2:
                newObstacle = Instantiate(wizardPrefab);
                obstacleSpawnPos.y = wizardYPos;
                break;

            case 3:
                newObstacle = Instantiate(rotatingObstaclePrefabs[Random.Range(0, rotatingObstaclePrefabs.Length)]);
                obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
                break;
        }

        newObstacle.transform.position = obstacleSpawnPos;
    }


    void SpawnHealth()
    {
        if(Random.Range(0,10) > healthSpawnProbability)
        {
            healthSpawnPos.x = mainCam.transform.position.x + 5f;
            healthSpawnPos.y = Random.Range(minHealthY, maxHealthY);
            Instantiate(healthPrefab, healthSpawnPos, Quaternion.identity);
        }
    }

}
