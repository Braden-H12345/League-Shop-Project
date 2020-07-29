using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItem : MonoBehaviour
{
   #region singleton
    public static SelectedItem instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public Item item;
    public Text itemCost;
    public Image artworkImage;
    public Image outline;
    public GameObject visualsToEnable;
    bool itemIsSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        visualsToEnable.SetActive(false);
    }

    private void Update()
    {
        itemCost.text = item.goldCost.ToString();
        outline.sprite = item.outlineArt;
        artworkImage.sprite = item.itemArt;
        if (itemIsSelected)
        {
            GoldControl.instance.GoldCheck(item);
        }
    }



    public void ItemActivated(Item itemActive)
    {
        itemIsSelected = true;
        item = itemActive;
        visualsToEnable.SetActive(true);
    }

    public Item ReturnItem()
    {
        return item;
    }
}

