using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    public Text itemCost;
    public Image artworkImage;
    public Image outline;
    // Start is called before the first frame update
    void Start()
    {
        outline.sprite = item.outlineArt;
        artworkImage.sprite = item.itemArt;
    }

    private void Update()
    {
        if (InventoryTrack.instance.items.Contains(item.buildsFrom1) || InventoryTrack.instance.items.Contains(item.buildsFrom2))
        {

            int tempGoldCost1 = item.goldCost;
            if (InventoryTrack.instance.items.Contains(item.buildsFrom1))
            {
                tempGoldCost1 -= item.buildsFrom1.goldCost;
            }
            if (InventoryTrack.instance.items.Contains(item.buildsFrom2))
            {
                tempGoldCost1 -= item.buildsFrom2.goldCost;
            }
            itemCost.text = tempGoldCost1.ToString();
        }
        if (!(InventoryTrack.instance.items.Contains(item.buildsFrom1) || InventoryTrack.instance.items.Contains(item.buildsFrom2)))
        {
            int normalCost = item.goldCost;
            itemCost.text = normalCost.ToString();
        }
    }

}
