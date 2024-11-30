using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockade : MonoBehaviour
{
    [SerializeField] GameObject floorBoss;

    // Start is called before the first frame update
    void Start()
    {
        floorBoss = GameObject.FindGameObjectWithTag("F1_Boss");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(floorBoss.GetComponent<Enemy>().isDead == true)
        {
            gameObject.SetActive(false); ;
        }*/
    }
}
