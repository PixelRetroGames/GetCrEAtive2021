using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{	
	private GameObject player;
    private GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.parent.gameObject;
        item = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack() {
        print("skrrr");
        player.GetComponent<Character>().dealDamage(item.GetComponent<InventoryItem>().damage);
    }
}
