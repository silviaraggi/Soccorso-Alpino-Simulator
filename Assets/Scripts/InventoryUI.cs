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
    private bool punti;
    private SceneInfo info;
    public int aiuto;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateUI;
        info = GameObject.Find("SceneInfo").GetComponent<SceneInfo>();
        punti = info.GetPunti();

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.None && Input.GetButtonDown("Inventory"))//||(GameObject.Find("stivali")&& (GameObject.Find("stivali").GetComponent<SkinnedMeshRenderer>().enabled==false)&& (GameObject.Find("ferito"))&& (GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>())&&(GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().GetInteract())&& GameObject.Find("fissaggi") && (GameObject.Find("fissaggi").GetComponent<SkinnedMeshRenderer>().enabled == false)) ||(GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>()&&GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().GetInteract()))
        {
            inventoryUI.SetActive(false);
            if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>())
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().m_MouseLook.SetCursorLock(true);
            if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>())
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().m_MouseLook.SetCursorLock(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && (Input.GetButtonDown("Inventory"))|| (GameObject.Find("stivali") && (GameObject.Find("stivali").GetComponent<SkinnedMeshRenderer>().enabled == true) && (GameObject.Find("ferito")) && (GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>())&&(GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().GetInteract()))||(GameObject.Find("stivali")&& (GameObject.Find("stivali").GetComponent<SkinnedMeshRenderer>().enabled==false)&& (GameObject.Find("ferito"))&& (GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>())&&(GameObject.Find("ferito").GetComponent<LightUpInteractableHelicopter>().GetInteract())&&GameObject.Find("fissaggi") && (GameObject.Find("fissaggi").GetComponent<SkinnedMeshRenderer>().enabled == false)) || (GameObject.Find("CaneUnity2") && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>() && GameObject.Find("CaneUnity2").GetComponent<InteractableDog>().GetInteract()))
        {
            
                if (GameObject.Find("ferito")&&(punti==false||aiuto>=2))
            {
                if (Input.GetButtonDown("Inventory"))
                    dialogueText.text = "Aiuta il ferito!";
                else if (GameObject.Find("stecca").GetComponent<SkinnedMeshRenderer>().enabled == false)
                    dialogueText.text = "Cerca di bloccare la gamba!";
                else if (GameObject.Find("bende").GetComponent<SkinnedMeshRenderer>().enabled == false)
                    dialogueText.text = "Usa le bende!";
                else if (GameObject.Find("fissaggi").GetComponent<SkinnedMeshRenderer>().enabled == false)
                    dialogueText.text = "Fissa il tutto";
            }
            else
            {
                dialogueText.text = "";
            }
            Cursor.lockState = CursorLockMode.None;
            inventoryUI.SetActive(true);
            if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>())
            GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().m_MouseLook.SetCursorLock(false);
            if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>())
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().m_MouseLook.SetCursorLock(false);
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
