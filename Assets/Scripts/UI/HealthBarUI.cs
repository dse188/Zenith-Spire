using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Slider playerHealth;
    //[SerializeField] Slider enemyHealth;

    //[SerializeField] EnemyStat_SO enemySO;
    [SerializeField] PlayerStats_SO playerSO;
    [SerializeField] Player playerCurrentHealth;
    //[SerializeField] Enemy enemyCurrentHealth;

    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI healthText;
    private void Start()
    {
        playerHealth.minValue = 0;
        playerHealth.maxValue = playerSO.maxHealth;
        playerHealth.value = playerSO.maxHealth;


        /*if (enemyCurrentHealth == null)
        {
            enemyCurrentHealth = FindObjectOfType<Enemy>();
        }

        if (enemyCurrentHealth != null)
        {
            enemyHealth.minValue = 0;
            enemyHealth.maxValue = enemyCurrentHealth.health; 
        }*/
    }

    private void Update()
    {
        playerHealth.value = playerCurrentHealth.health;
        playerHealth.maxValue = playerSO.maxHealth;

        healthText.text = playerCurrentHealth.health.ToString(); ;
        /*if(enemyCurrentHealth != null)
        {
            enemyHealth.value = enemyCurrentHealth.health;
        }*/
    }

    /*public void SetEnemy(Enemy enemy)
    {
        enemyCurrentHealth = enemy;

        // Find the enemy health slider in the enemy's child objects (assuming it's under a canvas)
        if (enemyCurrentHealth != null)
        {
            // Assuming the slider is a child of the enemy's canvas
            Slider enemyHealthSlider = enemyCurrentHealth.GetComponentInChildren<Slider>();

            if (enemyHealthSlider != null)
            {
                enemyHealth = enemyHealthSlider;
                enemyHealth.minValue = 0;
                enemyHealth.maxValue = enemyCurrentHealth.health;
            }
            else
            {
                Debug.LogError("SetEnemy: No Slider found in enemy's children!");
            }
        }
        else
        {
            Debug.LogWarning("SetEnemy: enemyCurrentHealth is null.");
        }
    }*/
}
