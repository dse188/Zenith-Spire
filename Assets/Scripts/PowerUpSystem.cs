using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    [SerializeField] PowerDrop powerDrop;
    [SerializeField] PlayerStats_SO playerStats_SO;
    float timer;
    //[SerializeField] EXP_Drop expDrop;
    //[SerializeField] GameObject expDrop;
    public bool isMagnetActive;


    private void Start()
    {
        //expDrop = GameObject.FindAnyObjectByType<EXP_Drop
        isMagnetActive = false;

        timer = powerDrop.expMagnetDuration;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Check the power type
            switch(powerDrop.powerType)
            {
                case PowerType.Heal:

                    playerStats_SO.playerHealth += powerDrop.healAmount;
                    if(playerStats_SO.playerHealth > playerStats_SO.maxHealth)
                    {
                        playerStats_SO.playerHealth = playerStats_SO.maxHealth;
                    }

                    /*if ((playerStats_SO.playerHealth += powerDrop.healAmount) >= playerStats_SO.maxHealth)
                    {
                        playerStats_SO.playerHealth = playerStats_SO.maxHealth;
                    }
                    else
                    {
                        playerStats_SO.playerHealth += powerDrop.healAmount;
                    }*/
                    break;
                case PowerType.Invincibility:
                    break;
                case PowerType.GlobalExpMagnet:
                    isMagnetActive = true;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
