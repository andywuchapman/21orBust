using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // magical dictionary technology discovered from r/gamedev that maps an item to its count which allows me to avoid instancing a bunch of items
    private Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();

    public void Add(ItemData data)
    {
        if (!items.ContainsKey(data)) // creates a dictionary entry if item is not owned
            items[data] = 0;

        items[data]++; // if owned add to the count
    }

    public int GetCount(ItemData data)
    {
        if (items.TryGetValue(data, out int count))
            return count;
        return 0;
    }
}