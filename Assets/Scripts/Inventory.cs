using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<Item, int> inventory;

    private void Awake()
    {
        inventory = new Dictionary<Item, int>();
    }

    public void Add(Item item, int count = 1)
    {
        if (!inventory.TryGetValue(item, out int current))
        {
            inventory.Add(item, count);
        }
        else
        {
            inventory[item] += count;
        }
    }
    public int Get(Item item)
    {
        if (inventory.TryGetValue(item, out int current))
        {
            return current;
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }
}

