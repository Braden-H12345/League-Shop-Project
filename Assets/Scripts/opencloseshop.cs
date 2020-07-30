using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opencloseshop : MonoBehaviour
{
    bool shopOpen;
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        shopOpen = false;
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //simply opens or closes the shop on proper key presses, uses bool to control if open

        if (shopOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                shop.SetActive(true) ;
            }
            shopOpen = true;
        }
        if (shopOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                shop.SetActive(false);
            }
            shopOpen = false;
        }
    }
}
