using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    //uses a different public image for each inventory slot, this way there can be different items in each slot
    public Image slot1Visuals;
    public Image slot2Visuals;
    public Image slot3Visuals;
    public Image slot4Visuals;
    public Image slot5Visuals;
    public Image slot6Visuals;

    //starting visuals of the item slots, basically just an empty square, used to reset the visuals after selling an item
    public Sprite startingVisuals;
    
    // same reasoning here as with the visuals
    Item slot1 = null;
    Item slot2 = null;
    Item slot3 = null;
    Item slot4 = null;
    Item slot5 = null;
    Item slot6 = null;
    void Update()
    {
        //if-else statement controlling each slot, uses count to determine if visuals should be active
        if (InventoryTrack.instance.items.Count >= 1)
        {
            slot1 = InventoryTrack.instance.items[0];
            slot1Visuals.sprite = InventoryTrack.instance.items[0].itemArt;
        }
        else
        {
            slot1 = null;
            slot1Visuals.sprite = startingVisuals;
        }

        //if nothing in the list for inventory, updates visuals to be the defaults
        if(InventoryTrack.instance.items.Count < 1)
        {
            slot2Visuals.sprite = startingVisuals;
            slot3Visuals.sprite = startingVisuals;
            slot4Visuals.sprite = startingVisuals;
            slot5Visuals.sprite = startingVisuals;
            slot6Visuals.sprite = startingVisuals;
        }
        if (InventoryTrack.instance.items.Count >= 2)
        {
            slot2 = InventoryTrack.instance.items[1];
            slot2Visuals.sprite = InventoryTrack.instance.items[1].itemArt;
        }
        else
        {
            slot2 = null;
            slot2Visuals.sprite = startingVisuals;
        }
        if (InventoryTrack.instance.items.Count >=3)
        {
            slot3 = InventoryTrack.instance.items[2];
            slot3Visuals.sprite = InventoryTrack.instance.items[2].itemArt;
        }
        else
        {
            slot3 = null;
            slot3Visuals.sprite = startingVisuals;
        }
        if (InventoryTrack.instance.items.Count >=4)
        {
            slot4 = InventoryTrack.instance.items[3];
            slot4Visuals.sprite = InventoryTrack.instance.items[3].itemArt;
        }
        else
        {
            slot4 = null;
            slot4Visuals.sprite = startingVisuals;
        }
        if (InventoryTrack.instance.items.Count >=5)
        {
            slot5 = InventoryTrack.instance.items[4];
            slot5Visuals.sprite = InventoryTrack.instance.items[4].itemArt;
        }
        else
        {
            slot5 = null;
            slot5Visuals.sprite = startingVisuals;
        }
        if (InventoryTrack.instance.items.Count >=6)
        {
            slot6 = InventoryTrack.instance.items[5];
            slot6Visuals.sprite = InventoryTrack.instance.items[5].itemArt;
        }
        else
        {
            slot6 = null;
            slot6Visuals.sprite = startingVisuals;
        }
    }


    //sell item function for each slot as they are triggered by buttons on each individual item slot
    public void sellItem1()
    {
        GoldControl.instance.SellItem(slot1);
        InventoryTrack.instance.Remove(0);
    }
    public void sellItem2()
    {
        GoldControl.instance.SellItem(slot2);
        InventoryTrack.instance.Remove(1);
    }
    public void sellItem3()
    {
        GoldControl.instance.SellItem(slot3);
        InventoryTrack.instance.Remove(2);
    }
    public void sellItem4()
    {
        GoldControl.instance.SellItem(slot4);
        InventoryTrack.instance.Remove(3);
    }
    public void sellItem5()
    {
        GoldControl.instance.SellItem(slot5);
        InventoryTrack.instance.Remove(4);
    }
    public void sellItem6()
    {
        GoldControl.instance.SellItem(slot6);
        InventoryTrack.instance.Remove(5);
    }
}
