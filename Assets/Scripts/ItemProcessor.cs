using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemProcessor : MonoBehaviour
{
    public string[] itemColorsNames;
    public Color[] itemColors;

    public string[] itemImagesNames;
    public Image[] itemImages;

    public Hashtable itemColorsMap = new Hashtable();
    public Hashtable itemImagesMap = new Hashtable();
    private bool started = false;


    // Start is called before the first frame update
    public void Init()
    {
        if (started) {
            return;
        }

        started = true;

        for (int i = 0; i < itemColorsNames.Length; i++) {
            itemColorsMap.Add(itemColorsNames[i], itemColors[i]);
        }

        for (int i = 0; i < itemImagesNames.Length; i++) {
            itemImagesMap.Add(itemImagesNames[i], itemImages[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color GetColor(string itemColor) {
        return (Color) itemColorsMap[itemColor];
    }

    public Image GetImage(string itemImage) {
        return (Image) itemImagesMap[itemImage];
    }
}
