using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float hp = 100;
    public string[] startingItems;
    public Inventory inventory;
    public string actionType;
    private InventoryItem selectedItem;

    void Start() {
        inventory = GetComponentInChildren<Inventory>();
        transform.GetComponentInChildren<Inventory>().UpdateItems(new List<string>(startingItems));

        if (tag.Equals("Enemy"))
        {
            setRandomItem();
            actionType = "attack";
        }
    }
    

    public void setRandomItem()
    {
        int itemIndex = Random.Range(0, inventory.currentItems.Count);
        setSelectedItem(inventory.currentItems[itemIndex].GetComponent<InventoryItem>());
    }
    public void selectRandomAction()
    {
        string[] types = {"attack", "defend"};
        
        actionType = types[Random.Range(0, 2)];
    }

    public void setHP(float newHP) {
        hp = Mathf.Max(0, newHP);
        GetComponentInChildren<Text>().text = "" + hp;
        if (hp != 0) return;
        if (CompareTag("Player")) {
            Application.Quit();
        } else {
            print("You won");
        }
    }

    public void dealDamage(float damage) {
        print("" + damage);
        target.GetComponent<Character>().setHP(target.GetComponent<Character>().hp - damage);
    }
    
    public void setSelectedItem(InventoryItem item)
    {
        if (selectedItem != null) {
            selectedItem.transform.GetChild(2).gameObject.SetActive(false);
        }

        selectedItem = item;

        if (CompareTag("Enemy"))
        {
            item.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void action()
    {
        
        if (actionType == "attack")
        {
            dealDamage(selectedItem.damage);
            selectedItem.durability -= 25;
            if (selectedItem.durability <= 0)
            {
                inventory.RemoveItem(selectedItem);
                selectedItem = null;
            }
        } else {
            setHP(hp + 50);
        }
        
        if (CompareTag("Enemy"))
        {
            setRandomItem();
        }
    }
}
