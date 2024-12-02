using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class IceSpearScript : MonoBehaviour
{
    [SerializeField] bool isHit;
    [SerializeField] float destroyTimer;
    float timer = 0;

    //Damage Calc stuffs
    public float iceSpearDamage;
    [SerializeField] float intMultiplier;
    Enemy enemy;
    Player player;

    [SerializeField] Animator iceSpearHitAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        player = Player.FindAnyObjectByType<Player>();
        DamageCalculation();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= destroyTimer)
        {
            Destroy(this.gameObject);
        }
    }

    public float DamageCalculation()
    {
        iceSpearDamage = player.playerStat.intelligence;// * intMultiplier;
        return iceSpearDamage;
        //return player.playerStat.intelligence * intMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("slime") || other.gameObject.CompareTag("F1_Boss") || other.gameObject.CompareTag("Enemy"))
        {
            isHit = true;
            Enemy hitEnemy = other.GetComponent<Enemy>();
            if (hitEnemy != null)
            {
                //iceSpearDamage = DamageCalculation();
                //hitEnemy.TakeDamage(player.playerStat.intelligence);
                hitEnemy.TakeDamage(iceSpearDamage);
            }
            //enemy.TakeDamage(iceSpearDamage);

            
            

            StartCoroutine(HitAnimation());
            
        }
    }

    private IEnumerator HitAnimation()
    {
        //iceSpearHitAnimator.SetBool("isHit", true);
        iceSpearHitAnimator.SetTrigger("EnemyHit");
        yield return new WaitForSeconds(0.15f);
        Destroy(this.gameObject);
    }
}
