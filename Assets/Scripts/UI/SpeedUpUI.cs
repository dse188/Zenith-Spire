using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedUpUI : MonoBehaviour
{
    [SerializeField] Button speedUpButton;
    [SerializeField] TextMeshProUGUI gameSpeedText;
    [HideInInspector]public float gameSpeed;

    private void Start()
    {
        gameSpeed = 1f;
        gameSpeedText.text = "x" + ((int)gameSpeed).ToString();
    }

    public void GameSpeedIncrease(float increaseSpeed)
    {
        gameSpeed += increaseSpeed;
        

        if (gameSpeed > 4f)
        {
            gameSpeed = 1f;
        }
        Time.timeScale = gameSpeed;
        gameSpeedText.text = "x" + ((int)gameSpeed).ToString();
    }


}
