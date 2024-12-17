using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    Heal,
    Invincibility,
    GlobalExpMagnet,
}

[CreateAssetMenu(fileName = "Power Ups", menuName = "Power Up")]
public class PowerDrop : ScriptableObject
{
    public PowerType powerType;
    public float healAmount;
    public float invincibleDuration;
    public float expMagnetDuration;
}
