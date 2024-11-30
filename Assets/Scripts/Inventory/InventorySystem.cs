using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] public List<Image> inventorySlotImage;
    //[SerializeField] public List<ItemPickUp> pickedupItems;
    [SerializeField] public List<LootSystem> pickedupItems;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the inventory slots as empty at the start.
        for (int i = 0; i < inventorySlotImage.Count; i++)
        {
            inventorySlotImage[i].enabled = false;
        }
    }

    /*public void AdditemToInventory(ItemPickUp item)
    {
        if(pickedupItems.Count < inventorySlotImage.Count)
        {
            pickedupItems.Add(item);

            //Find the next empty inventory slot
            int slotIndex = pickedupItems.Count - 1;
            inventorySlotImage[slotIndex].sprite = item.weaponSO.icon;
            inventorySlotImage[slotIndex].enabled = true;
            Debug.Log("Picked up item");
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }*/
    public void AdditemToInventory(LootSystem item)
    {
        if (pickedupItems.Count < inventorySlotImage.Count)
        {
            pickedupItems.Add(item);

            //Find the next empty inventory slot
            int slotIndex = pickedupItems.Count - 1;
            inventorySlotImage[slotIndex].sprite = item.weaponSO.icon;
            inventorySlotImage[slotIndex].enabled = true;
            Debug.Log("Picked up item");
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }
}
