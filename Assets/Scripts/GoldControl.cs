using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            GoldAtStart -= goldDeacrease;
        }

        goldDisplay.text = " " + GoldAtStart;
    }
    public void BuyItem(Item item)
    {
        if (InventoryTrack.instance.items.Count != 6)
        {
            if (GoldAtStart >= item.goldCost)
            {
                GoldAtStart -= item.goldCost;
                InventoryTrack.instance.Add(item);
            }
        }
    }
    public void SellItem(Item item)
    {
        InventoryTrack.instance.Remove(item);
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
}
