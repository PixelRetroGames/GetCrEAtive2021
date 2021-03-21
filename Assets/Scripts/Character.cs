using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float hp = 100;
    public string[] startingItems;
    public Inventory inventory;
    public string actionType;
    private InventoryItem selectedItem;
    public bool moving = false;
    public const float stepRatio = 0.8f;
    private float currentStep = 0.0f;
    private List<Vector3> targets = new List<Vector3>();

    public System.Action movementCallback;
    private bool shouldCallback = false;
    private Vector3 oldPosition;

    void Start()
    {
        inventory = GetComponentInChildren<Inventory>();
        transform.GetComponentInChildren<Inventory>().UpdateItems(new List<string>(startingItems));
        oldPosition = transform.GetChild(0).position;
        if (tag.Equals("Enemy"))
        {
            setRandomItem();
            actionType = "attack";
        }
    }

    void Update()
    {
        if (targets.Count != 0)
        {
            moving = true;

            inventory.gameObject.SetActive(false);
            currentStep += stepRatio * Time.deltaTime;
            transform.GetChild(0).position = Vector3.Lerp(oldPosition, targets[0], currentStep);

            if (currentStep > 1.0f)
            {
                oldPosition = targets[0];
                targets.RemoveAt(0);
                currentStep = 0.0f;
                moving = false;
            }
        }
        else
        {
            if (shouldCallback)
            {
                movementCallback();
                shouldCallback = false;
            }

            inventory.gameObject.SetActive(true);
        }
    }

    public void setCallback(System.Action callback)
    {
        movementCallback = callback;
        shouldCallback = true;
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

    public void addMovementTarget(Vector3 t)
    {
        targets.Add(t);
    }

    public void setHP(float newHP)
    {
        hp = Mathf.Max(0, newHP);
        GetComponentInChildren<Text>().text = "" + hp + "HP";
    }

    public void dealDamage(float damage)
    {
        print("" + damage);
        target.GetComponent<Character>().setHP(target.GetComponent<Character>().hp - damage);
    }

    public void setSelectedItem(InventoryItem item)
    {
        if (selectedItem != null)
        {
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
            selectedItem.updateDurabilityText();
            if (selectedItem.durability <= 0)
            {
                inventory.RemoveItem(selectedItem);
                selectedItem = null;
            }
        }
        else
        {
            print("Defend");
            setHP(hp + selectedItem.block);
        }

        if (CompareTag("Enemy"))
        {
            setRandomItem();
        }
    }
}