using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRadius;
    [SerializeField] bool canSpawn = true;
    public GameObject[] enemyPrefab;
    public float numEnemiesPresent;
    private float timer;
    public float globalTimer;

    [SerializeField] GameObject f1_Boss;
    bool f1_BossHasSpawned = false;
    [SerializeField] GameObject enemyCircleFormation;
    bool hasSpawnedCircleFormation = false;

    [SerializeField] EnemyScore enemyScore;

    private void Start()
    {
        timer = spawnRate;
        globalTimer = 0f;

        numEnemiesPresent = 0;
        //Instantiate(f1_Boss, new Vector3(-7, 1, 0), Quaternion.identity);
    }

    private void Update()
    {
        globalTimer += Time.deltaTime;

        if (numEnemiesPresent >= 50)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
        timer -= Time.deltaTime;
        if(timer <= 0 && canSpawn)
        {
            SpawnEnemy();
            timer = spawnRate;
        }

        if (Mathf.Abs(globalTimer%40.0f) < 0.01f && !hasSpawnedCircleFormation && canSpawn)
        {
            SpawnCircleFormation();
            hasSpawnedCircleFormation = true;
        }
        hasSpawnedCircleFormation = false;

        if((enemyScore.enemyKilled >= 100) && !f1_BossHasSpawned && canSpawn)
        {
            Instantiate(f1_Boss, new Vector3(0, 13, 0), Quaternion.identity);
            f1_BossHasSpawned = true;
        }
            
    }

    private Vector2 GetRandomPos()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        return spawnPos;
    }

    private void SpawnEnemy()
    {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[randomEnemy];
            Instantiate(enemyToSpawn, GetRandomPos(), Quaternion.identity);

            numEnemiesPresent++;
    }

    private Vector2 GetPlayerPos()
    {
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        return playerPos;
    }

    private void SpawnCircleFormation()
    {
        /*if(globalTimer == 10f)
        {
            Instantiate(enemyCircleFormation, GetPlayerPos(), Quaternion.identity);
        }*/
        Instantiate(enemyCircleFormation, GetPlayerPos(), Quaternion.identity);
    }
}
