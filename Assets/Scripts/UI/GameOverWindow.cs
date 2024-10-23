using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] GameObject gameOverWindow;
    PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    public void OpenWindow()
    {
        gameOverWindow.SetActive(true);
        pauseManager.PauseGame();
    }

    public void CloseWindow()
    {
        gameOverWindow.SetActive(false);
    }
}
