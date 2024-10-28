using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryWindow : MonoBehaviour
{

    [SerializeField] GameObject inventoryWindow;
    private bool isInventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isInventoryOpen == false)
            {
                OpenInventory();
                //isInventoryOpen = true;
            }
            else
            {
                CloseInventory();
                //isInventoryOpen = false;
            }
            
        }
    }

    private void OpenInventory()
    {
        inventoryWindow.SetActive(true);
        isInventoryOpen = true;
    }

    private void CloseInventory()
    {
        inventoryWindow.SetActive(false);
        isInventoryOpen = false;
    }

}
