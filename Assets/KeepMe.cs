using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour
{
    private static KeepMe instance;
    // Start is called before the first frame update
    void Awake()
    {
        
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
