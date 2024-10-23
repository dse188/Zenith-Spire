using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpeedUpUI speedUpUI;

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        //Time.timeScale = 1f;
        Time.timeScale = speedUpUI.gameSpeed;
    }
}
