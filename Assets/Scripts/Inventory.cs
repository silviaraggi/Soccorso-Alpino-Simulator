using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance od Inventory found");
            return;
        }
        instance = this;
    }


    #endregion

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangeCallback;

    public List<Item> items = new List<Item>();
    public int space = 20;

   

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Non c'è più spazio");
                return false;
            }
            items.Add(item);

            if (onItemChangeCallback != null) {
                onItemChangeCallback.Invoke();
            }
            
        }
        return true;

    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
   
}
;
