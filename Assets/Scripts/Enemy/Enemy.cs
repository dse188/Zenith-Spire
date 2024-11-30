using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStat_SO enemyStat;
    public float health;
    GameObject player;
    EnemySpawner enemySpawner;
    NewSpawner newSpawner;
    public bool isDead;
    //[SerializeField] Player player;

    [SerializeField] GameObject loot;
    GameObject blockade;
    [SerializeField] GameObject expDrop;
    //[SerializeField] List<GameObject> expDrop;

    private void Start()
    {
        health = enemyStat.enemyhealth;
        isDead = false;
        //player = GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = EnemySpawner.FindAnyObjectByType<EnemySpawner>();
        newSpawner = NewSpawner.FindAnyObjectByType<NewSpawner>();
        blockade = GameObject.FindGameObjectWithTag("Blockade");
        //expDrop = GameObject.FindGameObjectWithTag("EXP");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //Destroy game object.
        Destroy(gameObject);

        //player.GainEXP(enemyStat.expReward);
        //player.GetComponent<Player>().GainEXP(enemyStat.expReward);
        //Reward player with exp.

        //Decrement the amount of enemies present in the game.
        enemySpawner.numEnemiesPresent--;
        newSpawner.numEnemiesPresent--;

        //enemySpawner.enemyPresent.Remove(enemyPrefab[0]);

        float lootRange = Random.Range(1, 100);
        if(lootRange <= 25)
        {
            DropLoot();
        }
        
        if(this.gameObject.CompareTag("F1_Boss"))
        {
            //remove blockade
            blockade.SetActive(false);
        }

        DropEXP();

    }

    private void DropLoot()
    {
        Instantiate(loot, gameObject.transform.position, Quaternion.identity);
        
    }

    private void DropEXP()
    {
        Instantiate(expDrop, gameObject.transform.position, Quaternion.identity);
    }
}
