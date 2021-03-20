using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private GameObject enemy;

    private Inventory playerInventory;
    private Inventory enemyInventory;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        playerInventory = player.GetComponentInChildren<Inventory>();
        enemyInventory = enemy.GetComponentInChildren<Inventory>();
    }

    public void playerAction(string actionType)
    {
        player.GetComponent<Character>().actionType = actionType;
        player.GetComponent<Character>().action();
        enemyAction();
        enemy.GetComponent<Character>().selectRandomAction();
    }


    public void enemyAction() {
        enemy.GetComponent<Character>().action();
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}