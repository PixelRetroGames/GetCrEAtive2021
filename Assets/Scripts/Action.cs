using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private TurnController controller;
    private InventoryItem item;
    private Inventory inventory;
    void Start() {
        controller = GameObject.FindGameObjectWithTag("TurnController").GetComponent<TurnController>();
        item = transform.parent.gameObject.GetComponent<InventoryItem>();
        inventory = GetComponentInParent<Inventory>();
    }

    public void attack() {
        inventory.setSelectedItem(item);
        controller.playerAction("attack");
    }

    public void defend() {
        inventory.setSelectedItem(item);
        controller.playerAction("defend");
    }
}
