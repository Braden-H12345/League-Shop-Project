using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTrack : MonoBehaviour
{
    //singleton so there is only ever one inventory
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
    

    private void Start()
    {
       
    }

    //simply adds item to items list, backbone of inventory system
    public void Add (Item item)
    {
        if (items.Count <= 5)
        {
            items.Add(item);
        }
    }

    public void Remove(int index)
    {
        items.RemoveAt(index);
    }
}
