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
    public Text itemName;
    public Text description;
    public Text description2forAS;
    public Text description3forCrit;
    public Text description2ForMR;
    public Text description2ForHealth;


    // Start is called before the first frame update
    void Start()
    {
        visualsToEnable.SetActive(false);
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
        outline.sprite = item.outlineArt;
        artworkImage.sprite = item.itemArt;
        itemName.text = item.itemName;

        if(item.itemName == "Cloak of Agility")
        {
            description.text = "20% crit chance";
        }

        if(item.AD != 0)
        {
            description.text = item.AD.ToString() + " AD";
        }

        if(item.AP != 0)
        {
            description.text = item.AP.ToString() + " AP";
        }

        if (item.armor != 0)
        {
            description.text = item.armor.ToString() + " Armor";
        }

        if (item.magic_resist != 0)
        {
            description2ForMR.text = item.magic_resist.ToString() + " Magic Resist";
        }
        if(item.magic_resist == 0)
        {
            description2ForMR.text = " ";
        }

        if(item.health != 0)
        {
            description2ForHealth.text = item.health.ToString() + " health";
        }
        if(item.health == 0)
        {
            description2ForHealth.text = " ";
        }

        if(item.movespeedFlat != 0)
        {
            description.text = item.movespeedFlat.ToString() + " movespeed";
        }

        if(item.movespeedPercent != 0)
        {
            description.text = item.movespeedPercent.ToString() + "% movespeed";
        }

        if(item.crit_chance != 0)
        {
            description3forCrit.text = item.crit_chance.ToString() + "% crit chance";
        }
        if(item.crit_chance == 0)
        {
            description3forCrit.text = " ";
        }
        if(item.itemName == "Cloak of Agility")
        {
            description3forCrit.text = " ";
        }

        if(item.attack_speed != 0)
        {
            description2forAS.text = item.attack_speed.ToString() + "% attack speed";
        }
        if(item.attack_speed == 0)
        {
            description2forAS.text = " ";
        }

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

