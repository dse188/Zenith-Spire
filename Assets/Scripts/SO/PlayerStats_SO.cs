using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Player/Stats")]
public class PlayerStats_SO : ScriptableObject
{
    public float maxHealth;
    public float playerHealth;
    public int currentLevel;
    public float playerExp;
    public float expToLevel;
}
