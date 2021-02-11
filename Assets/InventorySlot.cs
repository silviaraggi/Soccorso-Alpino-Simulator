using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Item item;
    private GameObject cane;
    private GameObject berretto;
    private GameObject zaino;
    private GameObject guanti;
    private GameObject disperso;
    private GameObject maglia;



    private void Update()
    {
        if (item != null)
        {
            icon.sprite = item.icon;
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null&&GameObject.Find("CaneUnity2")&&GameObject.Find("CaneUnity2").GetComponent<CaneBosco>())
        {
            switch (this.name)
            {
                case "Maglia":
                    if (berretto.GetComponent<InteractableClue>().GetCollect() == false)
                        cane.GetComponent<CaneBosco>().GetNewClue(berretto);
                    break;
                case "Cappello":
                    if (zaino.GetComponent<InteractableClue>().GetCollect() == false)
                        cane.GetComponent<CaneBosco>().GetNewClue(zaino);
                    break;
                case "Zaino":
                    if (guanti.GetComponent<InteractableClue>().GetCollect() == false)
                        cane.GetComponent<CaneBosco>().GetNewClue(guanti);
                    break;
                case "Guanti":
                    if (disperso.GetComponent<Disperso>().GetDispersoState() == Disperso.DispersoState.Wander)
                        cane.GetComponent<CaneBosco>().GetNewClue(disperso);
                    break;
            }
                    GameObject.Find("Inventory").SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
}
