using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    [Header("Weapon Type")]
    HeavySword,
    Sword,
    Dagger,
    Bow,
    //More later
}

[CreateAssetMenu(fileName = "Weapons", menuName = "Weapons")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public WeaponType weaponType;
    public float attackDamage;
    public float attackRange;
    public float attackRate;
}
