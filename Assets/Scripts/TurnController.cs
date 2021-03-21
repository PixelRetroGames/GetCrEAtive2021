﻿using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        bool anim = false;
        if (actionType.Equals("attack"))
        {
            anim = true;
            System.Action x = enemyAction;
            Vector3 oldPlayerPos = player.transform.GetChild(0).transform.position;

            player.GetComponent<Character>().addMovementTarget(
                enemy.transform.GetChild(0).transform.position - new Vector3(1, 0, 0));
            player.GetComponent<Character>().addMovementTarget(oldPlayerPos);
            player.GetComponent<Character>().setCallback(x);
        }

        player.GetComponent<Character>().setSelectedItem(item);
        player.GetComponent<Character>().actionType = actionType;
        player.GetComponent<Character>().action();
        if (!anim)
        {
            enemyAction();
        }

        
       
    }

    public void enemyAction()
    {
        if (player.GetComponent<Character>().hp <= 0)
        {
            Application.Quit();
        } else if (enemy.GetComponent<Character>().hp <= 0)
        {
            SceneManager.LoadScene("Map", LoadSceneMode.Single);
            GameController controller = GameObject.Find("GameController").GetComponent<GameController>();
            controller.setNext(controller.currentNode);
        }
        
        if (enemy.GetComponent<Character>().actionType.Equals("attack")) {
            Vector3 oldEnemyPos = enemy.transform.GetChild(0).transform.position;
            enemy.GetComponent<Character>().addMovementTarget(
                player.transform.GetChild(0).transform.position - new Vector3(-1, 0, 0));
            enemy.GetComponent<Character>().addMovementTarget(oldEnemyPos);
        }

        enemy.GetComponent<Character>().action();
        enemy.GetComponent<Character>().selectRandomAction();
        enemy.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = enemy.GetComponent<Character>().actionType;
    }
    
}