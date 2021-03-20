using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ArrayList items = new ArrayList();
    public GameObject inventoryItem;
    public GameObject actionButton;
    public int numItems;
    public int rowSize = 2;
    // Start is called before the first frame update
    void Start() {
		float height = 0;
		float row = 0;
		float col = 0;
        for (int i = 1; i <= numItems; i++) {
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
