using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXP_UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider expBar;
    [SerializeField] PlayerStats_SO playerSO;
    [SerializeField] Player player;

    private void Start()
    {
        expBar.minValue = 0;
        expBar.maxValue = playerSO.expToLevel;
    }

    private void Update()
    {
        expBar.value = playerSO.playerExp;
        expBar.maxValue = playerSO.expToLevel;
        //expBar.value = player.currentExp;
        //levelText.text = "Lv " + playerSO.currentLevel.ToString();
        levelText.text = "Lv " + player.level.ToString();
    }
}
