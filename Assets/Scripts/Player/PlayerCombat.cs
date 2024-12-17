using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Transform attackPoint;
    float timer;

    [Header("Spin Slash")]
    [SerializeField] Animator animator;
    [SerializeField] GameObject weaponGameObject;
    [SerializeField] ParticleSystem weaponParticles;
    [SerializeField] float swordAnimationCompleteTime;

    [Header("Ice Spear")]
    [SerializeField] GameObject iceSpear;
    public bool isSkillObtained;
    public int iceSpearLearned;
    [SerializeField] Transform spearAttackPoint; //Always at the front of player
    [SerializeField] float iceSpearRate;
    [SerializeField] float force;
    float spearTimer;
    float destroyTimer = 0;

    [Header("Damage Floating Point")]
    [SerializeField] GameObject spinSlashDamageTextPrefab;
    


    private void Start()
    {
        timer = 2f;
        weaponSO.attackDamage = 25;
        weaponSO.attackRange = 2.5f;
        weaponSO.attackRate = 2f;

        weaponParticles.Stop();

        //Ice Spear
        spearTimer = 1.5f;
        isSkillObtained = true;
        iceSpearLearned = 0;
    }
    private void Update()
    {

        //Spin Attack
        timer = timer - Time.deltaTime;
        if(timer <= 0)
        {
            SpinSlash();
            timer = weaponSO.attackRate;
            StartCoroutine(SwordAnimation());
            /*Debug.Log(upgradeButton[0].isIceSpearLearned);
            Debug.Log(upgradeButton[1].isIceSpearLearned);
            Debug.Log(upgradeButton[2].isIceSpearLearned);*/
            //weaponGameObject.SetActive(false);
        }

        //Ice Spear
        spearTimer = spearTimer - Time.deltaTime;
        //if(spearTimer <= 0 && isSkillObtained == true)
        if (spearTimer <= 0 && iceSpearLearned >= 1)
        {
            IceSpear();
            spearTimer = iceSpearRate;
        }

    }
    private void SpinSlash()    //Attack()
    {
        weaponGameObject.SetActive(true);
        weaponParticles.Play();
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponSO.attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(weaponSO.attackDamage);
            Instantiate(spinSlashDamageTextPrefab, enemy.transform.position, Quaternion.identity);
        }
    }

    private void IceSpear()
    {
        //Fire my iceSpear gameObject towards my cursor(mouse position).
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = (mousePosition - spearAttackPoint.position).normalized;

        GameObject spear = Instantiate(iceSpear, spearAttackPoint.position, Quaternion.identity);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spear.transform.rotation = Quaternion.Euler(0, 0, angle);

        Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;


        /*if (rb!= null)
        {
            //rb.AddForce(direction * force, ForceMode2D.Impulse);
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        }*/
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, weaponSO.attackRange);
    }

    private IEnumerator SwordAnimation()
    {
        yield return new WaitForSeconds(swordAnimationCompleteTime);
        weaponGameObject.SetActive(false);
        weaponParticles.Stop();
    }
}
