using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : MonoBehaviour
{

    [SerializeField] GameObject menuWindow;
    [SerializeField] PauseManager pauseManager;
    private bool isMenuOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isMenuOpen == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void OpenMenu()
    {  
        menuWindow.SetActive(true);
        isMenuOpen = true;
        pauseManager.PauseGame();
    }

    public void CloseMenu()
    {
        menuWindow.SetActive(false);
        isMenuOpen = false;
        pauseManager.ResumeGame();
    }

}
