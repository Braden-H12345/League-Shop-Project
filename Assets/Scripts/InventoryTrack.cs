using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTrack : MonoBehaviour
{
    #region singleton
    public static InventoryTrack instance;
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than 1 instance found");
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public void Add (Item item)
    {
        if (items.Count <= 5)
        {
            items.Add(item);
        }
    }
    public void Remove(Item item)
    {
        items.Remove(item);

    }
}
