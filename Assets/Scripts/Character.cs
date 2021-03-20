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

    void Start() {
        inventory = GetComponentInChildren<Inventory>();
        transform.GetComponentInChildren<Inventory>().UpdateItems(new List<string>(startingItems));

        if (tag.Equals("Enemy"))
        {
            inventory.setRandomItem();
            actionType = "attack";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectRandomAction()
    {
        string[] types = {"attack", "defend"};
        actionType = types[((int) Random.Range(0, 100)) % 2];
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

    public void action()
    {
        InventoryItem nextItem = inventory.selectedItem;

        if (actionType == "attack")
        {
            dealDamage(nextItem.damage);
            nextItem.durability -= 25;
            print(nextItem.durability);
            if (nextItem.durability <= 0)
            {
                inventory.RemoveItem(nextItem);
                inventory.selectedItem = null;
            }
        } else {
            setHP(hp + 50);
        }
        
        if (tag.Equals("Enemy"))
        {
            inventory.setRandomItem();
        }
    }
}
