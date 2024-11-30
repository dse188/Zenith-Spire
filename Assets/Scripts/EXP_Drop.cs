using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP_Drop : MonoBehaviour
{
    [SerializeField] float expMagnetRadius;
    [SerializeField] float expFlySpeed;
    float expPoints;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Rigidbody2D rb;
    //[SerializeField] EnemyStat_SO enemyStat;
    GameObject player;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        //expPoints = this.gameObject.GetComponent<Enemy>().enemyStat.expReward;
        enemy = Enemy.FindAnyObjectByType<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, expMagnetRadius, playerLayer))
        {
            //have the exp gem fly towards the player.
            Vector2 newPosition = Vector2.MoveTowards(transform.position, player.transform.position, expFlySpeed * Time.deltaTime);
            rb.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Increase player exp.
            //this.gameObject.GetComponent<Player>().GainEXP(expPoints);
            player.GetComponent<Player>().GainEXP(enemy.enemyStat.expReward);
            Destroy(gameObject);
        }
    }
}
