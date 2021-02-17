using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public bool control = false;
    Inventory inventory;
    InventorySlot[] slots;
    public Text dialogueText;
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

        if (Input.GetButtonDown("Inventory")||(GameObject.Find("stivali")&& (GameObject.Find("stivali").GetComponent<SkinnedMeshRenderer>().enabled==false)&& (GameObject.Find("ferito"))&& (GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>())&&(GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().GetInteract())&& GameObject.Find("fissaggi") && (GameObject.Find("fissaggi").GetComponent<SkinnedMeshRenderer>().enabled == false)) ||(GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>()&&GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().GetInteract()))
        {
            if (GameObject.Find("ferito"))
            {
                if (Input.GetButtonDown("Inventory"))
                    dialogueText.text = "Aiuta il ferito!";
                else if (GameObject.Find("stecca").GetComponent<SkinnedMeshRenderer>().enabled == false)
                    dialogueText.text = "Cerca di bloccare la gamba!";
                else if (GameObject.Find("bende").GetComponent<SkinnedMeshRenderer>().enabled == false)
                    dialogueText.text = "Usa le bende!";
                else if (GameObject.Find("fissaggi").GetComponent<SkinnedMeshRenderer>().enabled == false)
                    dialogueText.text ="Fissa il tutto";
            }
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;
            /*if (GameObject.Find("CaneUnity2"))
                GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().SetInteract(false);*/
        }
        if (Cursor.lockState == CursorLockMode.Locked && (Input.GetButtonDown("Inventory"))|| (GameObject.Find("stivali") && (GameObject.Find("stivali").GetComponent<SkinnedMeshRenderer>().enabled == true) && (GameObject.Find("ferito")) && (GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>())&&(GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().GetInteract()))||(GameObject.Find("stivali")&& (GameObject.Find("stivali").GetComponent<SkinnedMeshRenderer>().enabled==false)&& (GameObject.Find("ferito"))&& (GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>())&&(GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().GetInteract())&&GameObject.Find("fissaggi") && (GameObject.Find("fissaggi").GetComponent<SkinnedMeshRenderer>().enabled == false)) || (GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>() && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().GetInteract()))
        {
            Cursor.lockState = CursorLockMode.None;
            if(GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>())
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().m_MouseLook.SetCursorLock(false);
            if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>())
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().m_MouseLook.SetCursorLock(false);
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            control = true;
            if (GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>())
                GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().SetInteract(false);
            if (GameObject.Find("ferito") && GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>())
                GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().SetInteract(false);
        }

        if (control)
        {

            control = false;
        }
        if (GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>())
            GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().SetInteract(false);
        if (GameObject.Find("ferito") && GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>() && GameObject.Find("fissaggi") && (GameObject.Find("fissaggi").GetComponent<SkinnedMeshRenderer>().enabled == false))
            GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().SetInteract(false);
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
    public Inventory GetInventory()
    {
        return inventory;
    }
}
