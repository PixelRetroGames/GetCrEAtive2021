using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ArrayList items = new ArrayList();
    public GameObject actionButton;
    public int numItems;
    public int rowSize = 2;

    public GameObject allItems;
    // Start is called before the first frame update
    void instantiateItems() {
		
    }


    public void initializeItems(string[] itemNames) {
        float row = 0;
		float col = 0;
        for (int i = 1; i <= itemNames.Length; i++) {
            GameObject inventoryItem = allItems.GetComponent<AllItems>().getItem(itemNames[i - 1]);
            float width = inventoryItem.GetComponent<RectTransform>().rect.width;
			print(transform.position.x);
            GameObject item = Instantiate(inventoryItem,
				new Vector3((transform.position.x + col), row, 0), Quaternion.identity);
            item.transform.SetParent(this.transform, false);
            items.Add(item);
			col += width;
			if(i % rowSize == 0) {
				row += width;
				col = 0.0f;
			}
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void clicked() {
    }
}
