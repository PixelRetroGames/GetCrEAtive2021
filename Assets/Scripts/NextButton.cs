﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController gameController;
    public void onClick() {
        gameController.setNext(transform.parent.gameObject.GetComponent<Node>());
    }

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}