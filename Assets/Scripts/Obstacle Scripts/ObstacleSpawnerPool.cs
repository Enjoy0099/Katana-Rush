using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObstacleSpawnerPool : MonoBehaviour
{

    private ScoreCounter scoreCounter;
    private float increaseSpeed_After = 20f;

    [SerializeField]
    private GameObject spikePrefab, swingingObstaclePrefab, wizardPrefab, healthPrefab;

    [SerializeField]
    private GameObject rotatingObstaclePrefab_1, rotatingObstaclePrefab_2, rotatingObstaclePrefab_3, 
                       rotatingObstaclePrefab_4, rotatingObstaclePrefab_5;

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

    private Vector3 obstacleSpawnPos, healthSpawnPos = Vector3.zero;

    private GameObject newObstacle;

    [SerializeField]
    private List<GameObject> spikePool, swingingobstaclePool, wizardPool, rotatingObstaclePool, healthPool;

    [SerializeField] private int initialObstaclesToSpawn = 10;

    [SerializeField]
    private float minHealthY = -0.72f, maxHealthY = -0.2f;

    [SerializeField] private int healthSpawnProbability = 97;

    private void Awake()
    {
        mainCam = Camera.main;

        scoreCounter = FindObjectOfType<ScoreCounter>();

        InitializeObstacles();
    }

    private void Update()
    {
        HandleObstacleSpawning();

        if (scoreCounter.GetScore() > increaseSpeed_After)
        {
            increaseSpeed_After += 20f;

            minSpawnWaitTime -= 0.2f;
            maxSpawnWaitTime -= 0.2f;

            if (minSpawnWaitTime <= 0f)
                minSpawnWaitTime = 0f;
            if (maxSpawnWaitTime <= 0.5f)
                maxSpawnWaitTime = 0.5f;
        }

    }

    void InitializeObstacles()
    {
        for (int i = 0; i < 9; i++)
            SpawnInitialObstacles(i);
        
    }

    void SpawnInitialObstacles(int obstacleType)
    {
        switch (obstacleType)
        {
            case 0:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(spikePrefab);
                    newObstacle.transform.SetParent(transform.GetChild(0));
                    spikePool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 1:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(swingingObstaclePrefab);
                    newObstacle.transform.SetParent(transform.GetChild(1));
                    swingingobstaclePool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 2:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(wizardPrefab);
                    newObstacle.transform.SetParent(transform.GetChild(2));
                    wizardPool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 3:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_1);
                    newObstacle.transform.SetParent(transform.GetChild(3));
                    rotatingObstaclePool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 4:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_2);
                    newObstacle.transform.SetParent(transform.GetChild(3));
                    rotatingObstaclePool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 5:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_3);
                    newObstacle.transform.SetParent(transform.GetChild(3));
                    rotatingObstaclePool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 6:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_4);
                    newObstacle.transform.SetParent(transform.GetChild(3));
                    rotatingObstaclePool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 7:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(rotatingObstaclePrefab_5);
                    newObstacle.transform.SetParent(transform.GetChild(3));
                    rotatingObstaclePool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 8:
                for (int i = 0; i < initialObstaclesToSpawn; i++)
                {
                    newObstacle = Instantiate(healthPrefab);
                    newObstacle.transform.SetParent(transform.GetChild(4));
                    healthPool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

        }
    }//spawn initial obstacles


    void SpawnObstacleInGame()
    {
        obstacleToSpawn = Random.Range(0, obstacleTypesCount);

        obstacleSpawnPos.x = mainCam.transform.position.x + 3f;


        switch (obstacleToSpawn)
        {
            case 0:
                for (int i = 0; i < spikePool.Count; i++)
                {
                    if (!spikePool[i].activeInHierarchy)
                    {
                        spikePool[i].SetActive(true);
                        obstacleSpawnPos.y = spikeYPos;
                        newObstacle = spikePool[i];
                        break;
                    }
                }
                break;

            case 1:
                for (int i = 0; i < swingingobstaclePool.Count; i++)
                {
                    if (!swingingobstaclePool[i].activeInHierarchy)
                    {
                        swingingobstaclePool[i].SetActive(true);
                        obstacleSpawnPos.y = Random.Range(swingObstacleMinY, swingObstacleMaxY);
                        newObstacle = swingingobstaclePool[i];
                        break;
                    }
                }
                break;

            case 2:
                for (int i = 0; i < wizardPool.Count; i++)
                {
                    if (!wizardPool[i].activeInHierarchy)
                    {
                        wizardPool[i].SetActive(true);
                        obstacleSpawnPos.y = wizardYPos;
                        newObstacle = wizardPool[i];
                        break;
                    }
                }
                break;

            case 3:
                while(true)
                {
                    int temp = Random.Range(0, rotatingObstaclePool.Count);
                    if (!rotatingObstaclePool[temp].activeInHierarchy)
                    {
                        rotatingObstaclePool[temp].SetActive(true);
                        obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
                        newObstacle = rotatingObstaclePool[temp];
                        break;
                    }
                }
                break;
        }

        newObstacle.transform.position = obstacleSpawnPos;
    }

    void SpawnHealthInGame()
    {
        if (Random.Range(0, 100) > healthSpawnProbability)
        {
            for (int i = 0; i < healthPool.Count; i++)
            {
                if (!healthPool[i].activeInHierarchy)
                {
                    healthPool[i].SetActive(true);
                    healthSpawnPos.x = mainCam.transform.position.x + 5f;
                    healthSpawnPos.y = Random.Range(minHealthY, maxHealthY);
                    healthPool[i].transform.position = healthSpawnPos;
                    break;
                }
            }
        }
    }


    void HandleObstacleSpawning()
    {
        if (Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
            SpawnObstacleInGame();
            SpawnHealthInGame();
        }
    }

}
