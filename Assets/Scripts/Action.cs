using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{	
	private GameObject playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = transform.parent.parent.parent.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack() {
        playerSprite.transform.position = new Vector3(
			playerSprite.transform.position.x + 5,
			playerSprite.transform.position.y,
			playerSprite.transform.position.z);
    }
}
