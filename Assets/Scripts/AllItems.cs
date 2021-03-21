using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] itemNames;
    public GameObject[] items;

    // Update is called once per frame

    public GameObject getItem(string name) {
        for (int i = 0; i < itemNames.Length; i++) {
            if (name.Equals(itemNames[i])) {
                return items[i];
            }
        }
        return null;
    }
}
