using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Enemy/Stats")]
public class EnemyStat_SO : ScriptableObject
{
    public float enemyhealth;
    public float enemyDamage;
    public float expReward;
}
