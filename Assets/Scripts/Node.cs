using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node[] next;

    private Line[] lines;

    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        lines = new Line[next.Length];
        for (int i = 0; i < next.Length; i++)
        {
            lines[i] = this.gameObject.AddComponent<Line>();
            lines[i].material = material;
            lines[i].Init();
            lines[i].gameObject1 = this.gameObject;
            lines[i].gameObject2 = next[i].gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
