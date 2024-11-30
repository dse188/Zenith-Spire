using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] EnemyStat_SO enemySO;

    private bool isPlayerInContact = false;
    private float damageInterval = 0.8f;
    private Coroutine damageCoroutine;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;
    [SerializeField] float bulletRate;
    float timer;

    private void Start()
    {
        timer = 0;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPosition = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Ensure your player is tagged as 'Player'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = bulletRate;
            //ShootBullet();
        }

        if (playerPosition != null)
        {
            /*Vector3 target = new Vector3(playerPosition.position.x, playerPosition.position.y, rb.position.y);
            Vector3 newPos = Vector3.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);*/

            Vector2 direction = ((Vector2)playerPosition.position - rb.position).normalized;

            // Apply movement directly
            rb.velocity = direction * moveSpeed;
        }

    }

    public void ShootBullet()   //youtube.com/watch?v=--u20SaCCow
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            isPlayerInContact = true;

            damageCoroutine = StartCoroutine(DamagePlayerOverTime(collision.collider.GetComponent<Player>()));
            //collision.collider.GetComponent<Player>().TakeDamage(enemySO.enemyDamage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") && isPlayerInContact)
        {
            isPlayerInContact = false;


        }    
    }

    private IEnumerator DamagePlayerOverTime(Player player)
    {
        while(isPlayerInContact)
        {
            player.TakeDamage(enemySO.enemyDamage);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
