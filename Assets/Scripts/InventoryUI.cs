using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public bool control=false;
    Inventory inventory;
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory= Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Inventory"))
        {
     
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;

         
        }
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetButtonDown("Inventory"))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Cursor.lockState = CursorLockMode.None;
            control = true;

        }

        if (control) {
  
            control = false;
        }




    }

    void UpdateUI()
    {
        for(int i=0; i<slots.Length; i++) 
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
