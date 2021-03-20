using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ArrayList items = new ArrayList();
    public GameObject inventoryItem;
    public GameObject actionButton;
    public int numItems;
    public int rowSize;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < numItems; i++) {
            float width = inventoryItem.GetComponent<RectTransform>().rect.width;
            float height = 0;
            GameObject item = Instantiate(inventoryItem, new Vector3((transform.position.x + i * width), 0, 0), Quaternion.identity);
            item.transform.SetParent(this.transform, false);
            items.Add(item);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void clicked() {
        Instantiate(actionButton, new Vector3(transform.position.x, transform.position.y - 10, 0), Quaternion.identity);
        Instantiate(actionButton, new Vector3(transform.position.x, transform.position.y - 20, 0), Quaternion.identity);
    }
}
