using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldControl : MonoBehaviour
{
    [SerializeField] Text goldDisplay = null;
    [SerializeField] int GoldAtStart = 0;
    [SerializeField] int goldIncrease = 0;
    [SerializeField] int goldDeacrease = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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

        goldDisplay.text = "Gold: " + GoldAtStart;
    }
}
