using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryItem : MonoBehaviour
{

	public Inventory inventory;
	public float damage;
    public float block;
    public float durability;
	
    public string itemName;
    
    public void clickedItem()
    {
	    GameObject player = transform.parent.parent.gameObject;
	    if (player.tag.Equals("Player"))
	    {
		    inventory = transform.parent.gameObject.GetComponent<Inventory>();
		    foreach (Transform child in inventory.transform)
		    {
			    child.GetChild(0).gameObject.SetActive(false);
			    child.GetChild(1).gameObject.SetActive(false);
		    }

		    transform.GetChild(0).gameObject.SetActive(true);
		    transform.GetChild(1).gameObject.SetActive(true);
	    }
    }
}
