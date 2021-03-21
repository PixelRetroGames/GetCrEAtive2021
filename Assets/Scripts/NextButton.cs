using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController gameController;
    public void onClick() {
        gameController.setNext(transform.parent.gameObject.GetComponent<Node>());
        SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single);
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
