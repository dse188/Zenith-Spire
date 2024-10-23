using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyStat_SO enemyStat;
    [SerializeField] public float health;
    [SerializeField] GameObject player;
    //[SerializeField] Player player;

    private void Start()
    {
        health = enemyStat.enemyhealth;
        //player = GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //Destroy game object.
        Destroy(gameObject);

        //player.GainEXP(enemyStat.expReward);
        player.GetComponent<Player>().GainEXP(enemyStat.expReward);
        //Reward player with exp.
    }
}
