using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI upgradeName;
    [SerializeField] TextMeshProUGUI affectedSkill;
    [SerializeField] TextMeshProUGUI description;

    [SerializeField] WeaponSO weaponSO;
    [SerializeField] PlayerStats_SO playerSO;
    [SerializeReference] PlayerMovement playerMovement;

    private ListOfUpgrades currentUpgrade;  //Store the current upgrade for each button.

    [SerializeField] GameObject heavySword;
    //[SerializeField] GameObject swordParticles;
    [SerializeField]private PlayerCombat player;
    //[SerializeField] GameObject player;

    public bool isIceSpearLearned;


    private void Start()
    {
        //isIceSpearLearned = false;
        player = PlayerCombat.FindAnyObjectByType<PlayerCombat>();
    }

    public void SetImage(ListOfUpgrades upgrades)
    {
        icon.sprite = upgrades.icon;
    }

    public void SetName(ListOfUpgrades upgrades)
    {
        upgradeName.text = upgrades.upgradeName;
    }

    public void SetAffectedSkill(ListOfUpgrades upgrades)
    {
        affectedSkill.text = upgrades.affectedSkill;
    }

    public void SetDescription(ListOfUpgrades upgrades)
    {
        description.text = upgrades.description;
        currentUpgrade = upgrades;
    }

    public void ApplyUpgrade()
    {
        switch(currentUpgrade.upgradeType)
        {
            case UpgradeType.DamageUp:
                weaponSO.attackDamage += 5f;
                break;
            case UpgradeType.AttackSpeedUp:
                weaponSO.attackRate -= 0.2f;
                break;
            case UpgradeType.RangeUp:
                weaponSO.attackRange += 0.1f;   //0.3

                Vector3 swordNewScale = heavySword.transform.localScale;
                swordNewScale.x += 0.025f;  //0.075
                swordNewScale.y += 0.05f;   //0.15
                swordNewScale.z += 0f;
                heavySword.transform.localScale = swordNewScale;
                break;
            case UpgradeType.HealthUp:
                playerSO.maxHealth += 10f;
                break;
            case UpgradeType.SpeedUp:
                playerMovement.movementSpeed += 0.5f;
                break;
            case UpgradeType.LearnSkill:
                //player.GetComponent<PlayerCombat>().isSkillObtained = true;
                //player.isSkillObtained = true;
                player.iceSpearLearned += 1;
                playerSO.intelligence += 5;
                break;
        }
    }

    public void OnButtonPressed()
    {
        FindObjectOfType<LevelUpWindow>().Upgrade(transform.GetSiblingIndex());
    }

    /*public void SetDamageUpgrade(ListOfUpgrades upgrades)
    {
        float damageUp = 5f;
        if (upgrades.upgradeType == UpgradeType.DamageUp)
        {
            weaponSO.attackDamage += damageUp;
        }
    }
    public void SetAttackSpeedUpgrade(ListOfUpgrades upgrades)
    {
        float attackSpeed = 0.2f;
        if (upgrades.upgradeType == UpgradeType.AttackSpeedUp)
        {
            weaponSO.attackRate -= attackSpeed;
        }
    }
    public void SetRangeUpgrade(ListOfUpgrades upgrades)
    {
        float rangeUp = 0.3f;
        if (upgrades.upgradeType == UpgradeType.RangeUp)
        {
            weaponSO.attackRange += rangeUp;
        }
    }
    public void SetHealthUpgrade(ListOfUpgrades upgrades)
    {
        float healthUp = 10f;
        if (upgrades.upgradeType == UpgradeType.HealthUp)
        {
            playerSO.maxHealth += healthUp;
        }
    }
    public void SetSpeedUpgrade(ListOfUpgrades upgrades)
    {
        float speedUp = 0.5f;
        if (upgrades.upgradeType == UpgradeType.SpeedUp)
        {
            playerMovement.movementSpeed += speedUp;
        }
    }*/
}
