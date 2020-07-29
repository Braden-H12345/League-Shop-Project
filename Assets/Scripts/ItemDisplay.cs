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
        itemCost.text = item.goldCost.ToString();
        outline.sprite = item.outlineArt;
        artworkImage.sprite = item.itemArt;
    }

}
