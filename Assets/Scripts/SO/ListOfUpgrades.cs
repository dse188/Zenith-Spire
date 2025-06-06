using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    DamageUp,
    AttackSpeedUp,
    RangeUp,
    HealthUp,
    SpeedUp,
    LearnSkill
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades")]
public class ListOfUpgrades : ScriptableObject
{
    public UpgradeType upgradeType;
    public string upgradeName;
    public string affectedSkill;
    public string description;
    public Sprite icon;

}
