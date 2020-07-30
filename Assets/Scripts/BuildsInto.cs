using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildsInto : MonoBehaviour
{
    public GameObject visualsToEnable;
    public Image artworkImage;
    public Image outline;
    // Start is called before the first frame update
    void Start()
    {
        visualsToEnable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildsIntoActive(Item item)
    {
        if(item.buildsInto != null)
        {
            artworkImage.sprite = item.buildsInto.itemArt;
            visualsToEnable.SetActive(true);
        }
        if(item.buildsInto == null)
        {
            visualsToEnable.SetActive(false);
        }
    }
}
