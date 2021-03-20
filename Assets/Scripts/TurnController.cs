using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private GameObject enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        
    }


    public void playerAction(InventoryItem item, string actionType)
    {
        player.GetComponent<Character>().setSelectedItem(item);
        player.GetComponent<Character>().actionType = actionType;
        player.GetComponent<Character>().action();
        enemyAction();
        enemy.GetComponent<Character>().selectRandomAction();
        enemy.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = enemy.GetComponent<Character>().actionType;

    }


    public void enemyAction() {
        enemy.GetComponent<Character>().action();
    }
    
}