using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOption : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] PlayerStats_SO playerSO;
    [SerializeReference] PlayerMovement playerMovement;
    Player player;

    private void Start()
    {
        player = Player.FindAnyObjectByType<Player>();
    }

    public void DamageUpgrade(ListOfUpgrades upgrades)
    {
        float damageUp = 10f;
        if(upgrades.upgradeType == UpgradeType.DamageUp)
        {
            weaponSO.attackDamage += damageUp;
        }
    }
    public void AttackSpeedUpgrade(ListOfUpgrades upgrades)
    {
        float attackSpeed = 0.2f;
        if (upgrades.upgradeType == UpgradeType.AttackSpeedUp)
        {
            weaponSO.attackRate -= attackSpeed;
        }
    }
    public void RangeUpgrade(ListOfUpgrades upgrades)
    {
        float rangeUp = 0.3f;
        if (upgrades.upgradeType == UpgradeType.RangeUp)
        {
            weaponSO.attackRange += rangeUp;
        }
    }
    public void HealthUpgrade(ListOfUpgrades upgrades)
    {
        float healthUp = 10f;
        if (upgrades.upgradeType == UpgradeType.HealthUp)
        {
            playerSO.playerHealth += healthUp;
        }
    }
    public void SpeedUpgrade(ListOfUpgrades upgrades)
    {
        float speedUp = 0.5f;
        if (upgrades.upgradeType == UpgradeType.SpeedUp)
        {
            playerMovement.movementSpeed += speedUp;
        }
    }

    public void LearnSkill(ListOfUpgrades upgrades)
    {
        if(upgrades.upgradeType == UpgradeType.LearnSkill)
        {
            //learn skill
            player.GetComponent<PlayerCombat>().isSkillObtained = true;
        }
    }
}
