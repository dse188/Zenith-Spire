using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloorTwo : MonoBehaviour
{
    [SerializeField] GameObject tbc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //SetActive tbc window.
            Debug.Log("GOAL!!!");
            tbc.SetActive(true);
            StartCoroutine(BackToMainMenu());
        }
    }

    private IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
