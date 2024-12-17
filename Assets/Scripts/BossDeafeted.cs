using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BossDeafeted : MonoBehaviour
{
    [SerializeField] GameObject bossPrefab;
    Enemy bossEnemy;
    [SerializeField] GameObject[] torches;

    // Start is called before the first frame update
    void Start()
    {
        if(bossPrefab != null)
        {
            //bossEnemy = GameObject.FindGameObjectWithTag("F1_Boss");
            bossEnemy = bossPrefab.GetComponent<Enemy>();
        }
        
        //bossEnemy = Enemy.FindFirstObjectByType<Enemy>();
        //bossEnemy = Enemy.FindAnyObjectByType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(bossPrefab.GetComponent<Enemy>().isDead == true)

        //if(bossEnemy.isDead)
        if(bossEnemy != null && bossEnemy.isDead)
        {
            LightUpTorches();
            //bossEnemy = null;
        }
        
    }

    public void LightUpTorches()
    {
        foreach (GameObject torch in torches)
        {
            Light2D torchLight = torch.GetComponent<Light2D>();
            if (torchLight != null)
            {
                torchLight.intensity = 1; // Adjust to desired intensity level
            }
        }
        Debug.Log("All torches are lit!");
    }
}
