using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;


public class EnemyScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI enemyScore;
    public float enemyKilled;
    bool canLightRed;
    // Start is called before the first frame update

    //Lighting
    [SerializeField] Light2D playerLight;
    void Start()
    {
        enemyKilled = 0;
        enemyScore.text = enemyKilled.ToString();

        canLightRed = true;

        if(playerLight != null)
        {
            playerLight.color = new Color(1, 1, 1); //light around the player starts fully white
        }

    }

    // Update is called once per frame
    void Update()
    {
        enemyScore.text = enemyKilled.ToString();
    }

    public float KillCounter()
    {
        enemyKilled += 1f;

        if(enemyKilled >= 101)
        {
            canLightRed = false;
        }
        if (playerLight != null && canLightRed)
        {
            // Calculate the red, green, and blue components based on kills
            float red = Mathf.Clamp01(1); // Scales red from 0 to 1 as kills go from 0 to 100
            float green = Mathf.Clamp01(1 - (enemyKilled / 100f)); // Green decreases from 1 to 0
            float blue = Mathf.Clamp01(1 - (enemyKilled / 100f)); // Blue decreases from 1 to 0

            // Set the new color
            playerLight.color = new Color(red, green, blue);
        }

        return enemyKilled;
    }
}
