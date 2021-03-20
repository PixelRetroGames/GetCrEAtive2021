using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public string itemType;
    public string itemColor;

    private ItemProcessor itemProcessor;

    // Start is called before the first frame update
    void Start()
    {
        itemProcessor = GameObject.FindGameObjectWithTag("ItemProcessor").GetComponent<ItemProcessor>();
        itemProcessor.Init();

        Image background = transform.GetComponent<Image>();
        background.color = itemProcessor.GetColor(itemColor);

        Image itemImage = transform.GetChild(0).GetComponent<Image>();
        itemImage.sprite = itemProcessor.GetImage(itemType).sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
