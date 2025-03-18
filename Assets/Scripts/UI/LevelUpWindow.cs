using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpWindow : MonoBehaviour
{
    [SerializeField] GameObject window;
    PauseManager pauseManager; 
    [SerializeField] List<UpgradeButton> upgradeButtons;

    // Start is called before the first frame update
    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenWindow(List<ListOfUpgrades> listOfUpgrades)
    {
        window.SetActive(true);
        pauseManager.PauseGame();

        for(int i = 0; i < listOfUpgrades.Count; i++)
        {
            upgradeButtons[i].SetImage(listOfUpgrades[i]);
            upgradeButtons[i].SetName(listOfUpgrades[i]);
            upgradeButtons[i].SetAffectedSkill(listOfUpgrades[i]);
            upgradeButtons[i].SetDescription(listOfUpgrades[i]);
/*          upgradeButtons[i].SetDamageUpgrade(listOfUpgrades[i]);
            upgradeButtons[i].SetAttackSpeedUpgrade(listOfUpgrades[i]);
            upgradeButtons[i].SetRangeUpgrade(listOfUpgrades[i]);
            upgradeButtons[i].SetHealthUpgrade(listOfUpgrades[i]);
            upgradeButtons[i].SetSpeedUpgrade(listOfUpgrades[i]);
*/
        }
    }

    public void CloseWindow()
    {
        window.SetActive(false);
        pauseManager.ResumeGame();
    }

    public void Upgrade(int pressedButtonID)
    {
        //GameManager.instance.playerTransform.GetComponent<Player>().Upgrade(pressedButtonID);
        upgradeButtons[pressedButtonID].ApplyUpgrade();
        CloseWindow();
    }
}
