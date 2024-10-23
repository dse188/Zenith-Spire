using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float bulletDamage;
    [SerializeField] PlayerStats_SO playerSO;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = playerObj.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<PlayerStats_SO>().playerHealth -= 20f;
            playerSO.playerHealth -= bulletDamage;
            if (playerSO.playerHealth <= 0f)
            {
                playerObj.GetComponent<Player>().Die();
            }
            //other.collider.GetComponent<Player>().TakeDamage(20f);
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Player>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }*/
}
