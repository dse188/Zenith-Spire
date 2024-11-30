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

    [SerializeField] GameObject f1_Boss;

    private void Start()
    {
        timer = spawnRate;
        numEnemiesPresent = 0;
        Instantiate(f1_Boss, new Vector3(-7, 1, 0), Quaternion.identity);
    }

    private void Update()
    {
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
}
