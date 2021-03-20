using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject other;
    public float hp = 100;

    public string[] startingItems;
    void Start() {
        transform.GetComponentInChildren<Inventory>().initializeItems(startingItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHP(float newHP) {
        hp = Mathf.Max(0, newHP);
        GetComponentInChildren<Text>().text = "" + hp;
        if (hp == 0) {
            if (this.tag == "Player") {
                Application.Quit();
            } else {
                print("You won");
            }
        }
    }

    public void dealDamage(float damage) {
        print("" + damage);
        other.GetComponent<Character>().setHP(other.GetComponent<Character>().hp - damage);
    }
}
