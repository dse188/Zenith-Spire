using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image slotImage;
    private Transform originalParent;
    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>(); // Reference to the canvas for UI scaling
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Save the original parent and move the slot to the canvas so it doesn't get masked
        originalParent = transform.parent;
        transform.SetParent(canvas.transform, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Follow the cursor
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if we dropped it in an equip slot
        GameObject hitObject = eventData.pointerEnter;

        if(hitObject != null && hitObject.CompareTag("EquipSlot"))
        {
            // Move the image to the equip slot
            transform.SetParent(hitObject.transform, false);
            transform.localPosition = Vector3.zero; // Center it
        }
        else
        {
            // If not dropped in an equip slot, return to the original inventory slot
            transform.SetParent(originalParent, false);
            transform.localPosition = Vector3.zero;
        }
    }
}
