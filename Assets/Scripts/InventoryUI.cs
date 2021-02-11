using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public bool control = false;
    Inventory inventory;
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Inventory") ||(GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().GetInteract()))
        {

            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;
            /*if (GameObject.Find("CaneUnity2"))
                GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().SetInteract(false);*/
        }
        if (Cursor.lockState == CursorLockMode.Locked && (Input.GetButtonDown("Inventory")) || (GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().GetInteract()))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Cursor.lockState = CursorLockMode.None;
            control = true;
            if (GameObject.Find("CaneUnity2"))
                GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().SetInteract(false);
        }

        if (control)
        {

            control = false;
        }
        if (GameObject.Find("CaneUnity2"))
            GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().SetInteract(false);
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
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
