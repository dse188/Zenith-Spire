using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] GameOverWindow gameOverWindow;

    private void Start()
    {
        
    }

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenuScene");
        gameOverWindow.CloseWindow();
    }
}
