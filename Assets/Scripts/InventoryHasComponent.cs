using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHasComponent : MonoBehaviour
{
    public Button sellButton;
    Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        startColor = sellButton.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryTrack.instance.items.Count >= 1)
        {
            sellButton.GetComponent<Image>().color = Color.blue;
        }
        if (InventoryTrack.instance.items.Count == 0)
        {
            sellButton.GetComponent<Image>().color = startColor;
        }
    }
}
