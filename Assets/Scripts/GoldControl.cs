using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class GoldControl : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GoldAtStart += goldIncrease;
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = addMoney;
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GoldAtStart -= goldDeacrease;
        }

        goldDisplay.text = " " + GoldAtStart;
    }
    public void SellItem(Item item)
    {
        GoldAtStart += item.sellAmount;
    }

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
    public void CheckForBuildFrom(Item item)
    {
        if (InventoryTrack.instance.items.Contains(item.buildsFrom1) || InventoryTrack.instance.items.Contains(item.buildsFrom2))
        {

            int tempGoldCost1 = item.goldCost;
            if (InventoryTrack.instance.items.Contains(item.buildsFrom1))
            {
                int tempIndex1 = InventoryTrack.instance.items.IndexOf(item.buildsFrom1);
                InventoryTrack.instance.items.Remove(item.buildsFrom1);
                RemoveInventoryVisuals(tempIndex1);
                tempGoldCost1 -= item.buildsFrom1.goldCost;
            }
            if (InventoryTrack.instance.items.Contains(item.buildsFrom2))
            {
                int tempIndex2 = InventoryTrack.instance.items.IndexOf(item.buildsFrom2);
                InventoryTrack.instance.items.Remove(item.buildsFrom2);
                RemoveInventoryVisuals(tempIndex2);
                tempGoldCost1 -= item.buildsFrom2.goldCost;
            }
            BuyItem(item, tempGoldCost1);
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

    void RemoveInventoryVisuals(int slotNum)
    {
        
    }
}
