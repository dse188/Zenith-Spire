using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsWindow : MonoBehaviour
{
    [SerializeField] GameObject statsWindow;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] PlayerStats_SO playerStats_SO;
    //[SerializeField] GameObject player;

    [SerializeField] TextMeshProUGUI strText;
    [SerializeField] TextMeshProUGUI intText;
    [SerializeField] TextMeshProUGUI dexText;

    bool isWindowOpen = false;

    private void Start()
    {
        strText.text = playerStats_SO.strength.ToString();
        intText.text = playerStats_SO.intelligence.ToString();
        dexText.text = playerStats_SO.dexterity.ToString();
    }

    private void Update()
    {
        if(isWindowOpen == true && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseStatsWindow();
        }
    }


    public void OpenStatsWindow()
    {
        if (isWindowOpen == false)
        {
            statsWindow.SetActive(true);
            isWindowOpen = true;
            //pauseManager.PauseGame();

        }
    }

    public void CloseStatsWindow()
    {
        if (isWindowOpen == true)
        {
            statsWindow.SetActive(false);
            isWindowOpen = false;
            //pauseManager.ResumeGame();
        }
    }
}
