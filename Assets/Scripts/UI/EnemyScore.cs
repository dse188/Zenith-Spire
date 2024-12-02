using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EnemyScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI enemyScore;
    public float enemyKilled;
    // Start is called before the first frame update
    void Start()
    {
        enemyKilled = 0;
        enemyScore.text = enemyKilled.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        enemyScore.text = enemyKilled.ToString();
    }

    public float KillCounter()
    {
        enemyKilled += 1f;
        return enemyKilled;
    }
}
