using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] public WeaponSO weaponSO;
    [SerializeField] InventorySystem inventorySystem;

    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = InventorySystem.FindAnyObjectByType<InventorySystem>();
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = weaponSO.icon;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //inventorySystem.pickedupItems.Add(this);
            //inventorySystem.AdditemToInventory(this);
            Destroy(gameObject);

            //Debug.Log("Picked up items count = :" + inventorySystem.pickedupItems.Count);
        }
    }
}
