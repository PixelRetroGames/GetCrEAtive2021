using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Node currentNode;


    public void setHighlights() {
        currentNode.gameObject.transform.Find("Highlight").gameObject.SetActive(true);
        for (int i = 0; i < currentNode.next.Length; i++) {
            currentNode.next[i].gameObject.transform.Find("HighlightNext").gameObject.SetActive(true);
        }
    }

    public void resetHighlights() {
        currentNode.gameObject.transform.Find("Highlight").gameObject.SetActive(false);
        for (int i = 0; i < currentNode.next.Length; i++) {
            currentNode.next[i].gameObject.transform.Find("HighlightNext").gameObject.SetActive(false);
        }
    }

    public void setNext(Node next) {
        resetHighlights();
        currentNode = next;
        setHighlights();
    }

    // Start is called before the first frame update
    void Start()
    {
        setHighlights();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
