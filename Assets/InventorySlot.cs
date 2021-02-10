using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public RawImage icon;
    public Item item;

    private void Update()
    {
        if (item != null)
        {
            icon = item.icon;
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            GameObject.Find("Inventory").SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
