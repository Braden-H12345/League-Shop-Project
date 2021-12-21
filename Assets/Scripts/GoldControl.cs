using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class GoldControl : MonoBehaviour
{
    //singleton to ensure there is only one gold controller throughout application
    #region singleton
    public static GoldControl instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 instance found");
        }
        instance = this;
    }
    #endregion

    [SerializeField] Text goldDisplay = null;
    [SerializeField] int GoldAtStart = 0;
    [SerializeField] int goldIncrease = 0;
    [SerializeField] int goldDeacrease = 0;
    [SerializeField] Button buyButton = null;
    [SerializeField] AudioClip addMoney;
    Color startColorBuy;
    // Start is called before the first frame update
    void Start()
    {
        startColorBuy = buyButton.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //on Q press, adds money/plays audio
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GoldAtStart += goldIncrease;
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = addMoney;
            audio.Play();
        }
        //on W press, reduces money
        if (Input.GetKeyDown(KeyCode.W))
        {
            GoldAtStart -= goldDeacrease;
        }

        goldDisplay.text = " " + GoldAtStart;
    }

    //sells item for sell amount
    public void SellItem(Item item)
    {
        GoldAtStart += item.sellAmount;
    }

    //check if there is enough gold to buy item, if so it changes the buy button color for visual feedback
    public void GoldCheck(Item item)
    {
        if (GoldAtStart >= item.goldCost)
        {
            buyButton.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            buyButton.GetComponent<Image>().color = startColorBuy;
        }
    }

    // checks if an item builds from another item in the player's inventory, if it does the cost is reduced, calls Buy function at end
    // so that cost can be updated from this function
    //this function acts as a middleman between the buy button being pressed and the item going to the players inventory
    public void CheckForBuildFrom(Item item)
    {
        if (InventoryTrack.instance.items.Contains(item.buildsFrom1) || InventoryTrack.instance.items.Contains(item.buildsFrom2))
        {

            int tempGoldCost1 = item.goldCost;
            if(item.buildsFrom1 != item.buildsFrom2)
            {
                if (InventoryTrack.instance.items.Contains(item.buildsFrom1))
                {
                    int tempIndex1 = InventoryTrack.instance.items.IndexOf(item.buildsFrom1);
                    InventoryTrack.instance.items.Remove(item.buildsFrom1);
                    tempGoldCost1 -= item.buildsFrom1.goldCost;
                }
                if (InventoryTrack.instance.items.Contains(item.buildsFrom2))
                {
                    int tempIndex2 = InventoryTrack.instance.items.IndexOf(item.buildsFrom2);
                    InventoryTrack.instance.items.Remove(item.buildsFrom2);
                    tempGoldCost1 -= item.buildsFrom2.goldCost;
                }
                BuyItem(item, tempGoldCost1);
            }
            else
            {
                int count = 0;
                foreach(Item currentItem in InventoryTrack.instance.items)
                {
                    if(currentItem == item.buildsFrom1)
                    {
                        count++;
                    }
                }
                if(count == 1)
                {
                    if (InventoryTrack.instance.items.Contains(item.buildsFrom1))
                    {
                        int tempIndex1 = InventoryTrack.instance.items.IndexOf(item.buildsFrom1);
                        InventoryTrack.instance.items.Remove(item.buildsFrom1);
                        tempGoldCost1 -= item.buildsFrom1.goldCost;
                    }
                }
                else if(count >= 2)
                {
                    if (InventoryTrack.instance.items.Contains(item.buildsFrom1))
                    {
                        int tempIndex1 = InventoryTrack.instance.items.IndexOf(item.buildsFrom1);
                        InventoryTrack.instance.items.Remove(item.buildsFrom1);
                        tempGoldCost1 -= item.buildsFrom1.goldCost;
                    }
                    if (InventoryTrack.instance.items.Contains(item.buildsFrom2))
                    {
                        int tempIndex2 = InventoryTrack.instance.items.IndexOf(item.buildsFrom2);
                        InventoryTrack.instance.items.Remove(item.buildsFrom2);
                        tempGoldCost1 -= item.buildsFrom2.goldCost;
                    }
                }
                BuyItem(item, tempGoldCost1);
            }
        }
        if (!(InventoryTrack.instance.items.Contains(item.buildsFrom1) || InventoryTrack.instance.items.Contains(item.buildsFrom2)))
        {

            int normalCost = item.goldCost;
            BuyItem(item, normalCost);
        }
    }


    public void BuyItem(Item item, int cost)
    {
        if (InventoryTrack.instance.items.Count <= 5)
        {
            if (GoldAtStart >= cost)
            {
                GoldAtStart -= cost;
                InventoryTrack.instance.Add(item);
            }
        }
    }

    //was going to use this but ended up not using it, kept in as comment in case I ended up using it
   /* void RemoveInventoryVisuals(int slotNum)
    {
        
    }*/
}
