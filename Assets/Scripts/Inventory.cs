using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> currentItems;
    public int rowSize = 2;
    public GameObject allItems;
    public List<string> currentItemNames;
    public InventoryItem selectedItem;
    void Start()
    {
    }

    public void UpdateItems(List<string> newItems)
    {
	    currentItemNames = newItems;
	    foreach (GameObject item in currentItems)
	    {
		    Destroy(item);
	    }
	    
	    currentItems.Clear();
	    
        float row = 0;
		float col = 0;
        for (int i = 1; i <= newItems.Count; i++)
        {
	        GameObject inventoryItem = allItems.GetComponent<AllItems>().getItem(newItems[i-1]);
	        float width = inventoryItem.GetComponent<RectTransform>().rect.width;
            GameObject item = Instantiate(inventoryItem,
				new Vector3((transform.position.x + col), row, 0), Quaternion.identity);
            item.transform.SetParent(transform, false);
            currentItems.Add(item);

			col += width;
			if(i % rowSize == 0) {
				row += width;
				col = 0.0f;
			}
        }
    }

    public void setRandomItem()
    {
	    selectedItem = currentItems[0].GetComponent<InventoryItem>();
    }
    
    public void RemoveItem(InventoryItem item)
    {
	    currentItemNames.Remove(item.itemName);
	    UpdateItems(currentItemNames);
    }

    public void setSelectedItem(InventoryItem item)
    {
	    selectedItem = item;
    }
    
}
