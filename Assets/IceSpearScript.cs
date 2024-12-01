using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpearScript : MonoBehaviour
{
    float iceSpearDamage;
    [SerializeField] float intMultiplier;

    [SerializeField] float destroyTimer;
    float timer = 0;

    //Damage Calc stuffs
    Enemy enemy;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.FindAnyObjectByType<Player>();
        enemy = Enemy.FindAnyObjectByType<Enemy>();
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
        iceSpearDamage = player.playerStat.intelligence * intMultiplier;
        return iceSpearDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("slime") || other.gameObject.CompareTag("F1_Boss"))
        {
            enemy.TakeDamage(iceSpearDamage);
            Destroy(this.gameObject);
        }
    }
}
