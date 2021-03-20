using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

	public GameObject inventory;
    public float damage;
    public float block;
    // Start is called before the first frame update
    void Start() {
        inventory = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickedItem() {
		foreach(Transform child in inventory.transform) {
        	child.GetChild(0).gameObject.SetActive(false);
       		child.GetChild(1).gameObject.SetActive(false);
		}

        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(true);
    }
}
