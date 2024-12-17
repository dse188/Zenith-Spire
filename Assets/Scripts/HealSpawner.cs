using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] GameObject healPrefab;
    [SerializeField] GameObject[] spawnLocations;

    [SerializeField] float spawnRadius = 0.2f; // Radius to check for overlap
    [SerializeField] LayerMask spawnLayerMask; // Layer mask for spawned prefabs

    bool canSpawn;
    float timer;
    int spawnCount;

    void Start()
    {
        timer = 0f;
        spawnCount = 0;
        canSpawn = true;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (spawnCount >= 30)
        {
            canSpawn = false;
            return; // Stop spawning after 10 heals
        }

        if (canSpawn && timer >= 8f) // Spawn every 15 seconds
        {
            SpawnHeal();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnHeal()
    {
        int attempts = 0; // Limit attempts to avoid infinite loops
        bool spawned = false;

        while (!spawned && attempts < spawnLocations.Length)
        {
            int randomIndex = Random.Range(0, spawnLocations.Length);
            Vector3 spawnPosition = spawnLocations[randomIndex].transform.position;

            // Check if the area is free using Physics2D.OverlapCircle
            if (!Physics2D.OverlapCircle(spawnPosition, spawnRadius, spawnLayerMask))
            {
                Instantiate(healPrefab, spawnPosition, Quaternion.identity);
                spawnCount++;
                spawned = true; // Successfully spawned
            }
            attempts++;
        }

        if (!spawned)
        {
            Debug.LogWarning("No available spawn locations for heal prefab.");
        }
    }
}
