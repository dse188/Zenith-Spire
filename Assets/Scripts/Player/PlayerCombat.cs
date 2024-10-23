using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Transform attackPoint;
    float timer;

    [SerializeField] Animator animator;
    [SerializeField] GameObject weaponGameObject;
    [SerializeField] ParticleSystem weaponParticles;
    [SerializeField] float swordAnimationCompleteTime;

    private void Start()
    {
        timer = 2f;
        weaponSO.attackDamage = 25;
        weaponSO.attackRange = 2.5f;
        weaponSO.attackRate = 2f;
    }
    private void Update()
    {
        timer = timer - Time.deltaTime;
        if(timer <= 0)
        {
            Attack();
            timer = weaponSO.attackRate;
            StartCoroutine(SwordAnimation());
            //weaponGameObject.SetActive(false);
        }
    }
    private void Attack()
    {
        weaponGameObject.SetActive(true);
        weaponParticles.Play();
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponSO.attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(weaponSO.attackDamage);
        }
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
