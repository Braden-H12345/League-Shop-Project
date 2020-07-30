using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //I used this script on items I wanted to turn off the visuals for on the program start
        //that is all this script does
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
