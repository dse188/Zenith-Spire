using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats_SO playerStat;

    public float health;
    public int level;
    public float currentExp;
    public float expToLevel;

    [SerializeField] GameOverWindow gameOverWindow;

    [SerializeField] LevelUpWindow levelUpWindow;
    [SerializeField] List<ListOfUpgrades> upgrades;
    [SerializeField] List<ListOfUpgrades> selectUpgrade;
    [SerializeField] List<ListOfUpgrades> acquiredUpgrades;
  

    private void Start()
    {
        playerStat.currentLevel = 1;

        //health = playerStat.playerHealth;
        playerStat.playerHealth = 100;
        playerStat.maxHealth = 100;
        playerStat.playerExp = 0;
        playerStat.expToLevel = 100f;

        playerStat.strength = 10;
        playerStat.intelligence = 10;
        playerStat.dexterity = 10;
    }

    private void Update()
    {
        level = playerStat.currentLevel;
        health = playerStat.playerHealth;
    }

    public void TakeDamage(float damage)
    {
        playerStat.playerHealth -= damage;
        if (playerStat.playerHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Destroy game object.
        gameOverWindow.OpenWindow();
    }

    public void GainEXP(float exp)
    {
        playerStat.playerExp += exp;

        if (playerStat.playerExp >= playerStat.expToLevel)
        {
            LevelUp();
        }
        //return playerStat.playerExp;
    }

    public void LevelUp()
    {
        playerStat.playerExp = 0;
        playerStat.currentLevel++;
        playerStat.expToLevel += (playerStat.expToLevel * 0.2f);

        if (selectUpgrade == null)
        {
            selectUpgrade = new List<ListOfUpgrades>();
        }
        selectUpgrade.Clear();
        selectUpgrade.AddRange(GetUpgrades(3));

        levelUpWindow.OpenWindow(selectUpgrade);
    }

    public void Upgrade(int selectedUpgradeID)
    {
        ListOfUpgrades upgradeObj = selectUpgrade[selectedUpgradeID];

        if (acquiredUpgrades == null)
        {
            acquiredUpgrades = new List<ListOfUpgrades>();
        }
        acquiredUpgrades.Add(upgradeObj);
    }

    public List<ListOfUpgrades> GetUpgrades(int count)
    {
        /*List<ListOfUpgrades> upgradeList = new List<ListOfUpgrades>();
        

        if(count > upgrades.Count)
        {
            count = upgrades.Count; //Basically, if there are not enough upgrades available then only show the available upgrades.
        }

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, upgrades.Count);
            upgradeList.Add(upgrades[randomIndex]);
            upgrades.RemoveAt(randomIndex);
            //upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;*/

        List<ListOfUpgrades> upgradeList = new List<ListOfUpgrades>();
        HashSet<int> selectedIndices = new HashSet<int>();

        if (upgrades.Count < count)
        {
            // If not enough unique upgrades, replenish from acquiredUpgrades
            upgrades.AddRange(acquiredUpgrades);
            acquiredUpgrades.Clear();
        }

        while (upgradeList.Count < count && upgrades.Count > 0)
        {
            int randomIndex = Random.Range(0, upgrades.Count);

            // Ensure no duplicates within this level-up
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
                upgradeList.Add(upgrades[randomIndex]);
            }
        }

        return upgradeList;
    }
}
