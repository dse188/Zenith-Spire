using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnRate =  1f;
    [SerializeField] float spawnRadius = 7f;
    [SerializeField] bool canSpawn = true;
    public GameObject[] enemyPrefab;
    //public List<GameObject> enemyPresent;
    public float numEnemiesPresent;
    //[SerializeField] HealthBarUI healthBarUI;
    //[SerializeField] Enemy newEnemy;

    private void Start()
    {
        numEnemiesPresent = 0;
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if(numEnemiesPresent >= 10)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
        /*if (enemyPrefab[0].GetComponent<Enemy>().isDead == true)
        {
            enemyPresent.Remove(enemyPrefab[0]);
        }*/
    }

    private Vector2 GetRandomPos()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        return spawnPos;
    }



    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(canSpawn)
        {
            yield return wait;
            int randomEnemy = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[randomEnemy];
            Instantiate(enemyToSpawn, GetRandomPos(), Quaternion.identity);

            numEnemiesPresent++;


            /*enemyPresent.Add(enemyPrefab[0]);
            if(enemyPresent.Count >= 30)
            {
                canSpawn = false;
            }
            else
            {
                canSpawn = true;
            }*/

            /*// Instantiate the enemy and assign it to a variable
            GameObject newEnemyObject = Instantiate(enemyToSpawn, GetRandomPos(), Quaternion.identity);
            Enemy newEnemy = newEnemyObject.GetComponent<Enemy>();

            // Find the health slider inside the enemy's canvas
            Slider enemyHealthSlider = newEnemyObject.GetComponentInChildren<Slider>();

            if (enemyHealthSlider != null)
            {
                // Pass the new enemy and its health slider to the HealthBarUI
                healthBarUI.SetEnemy(newEnemy);
            }
            else
            {
                Debug.LogError("No health slider found in enemy prefab!");
            }*/
        }

    }
}
