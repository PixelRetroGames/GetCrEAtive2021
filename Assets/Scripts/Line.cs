using UnityEngine;
 using System.Collections;
 
 public class Line : MonoBehaviour {
 
     public GameObject gameObject1;          // Reference to the first GameObject
     public GameObject gameObject2;          // Reference to the second GameObject

     private GameObject lineHolder;

     public Material material;
     private bool drawn = false;
 
     private LineRenderer line;                           // Line Renderer
 
     // Use this for initialization
     public void Init () {
         lineHolder = new GameObject("line holder");
         // Add a Line Renderer to the GameObject
         line = lineHolder.gameObject.AddComponent<LineRenderer>();
         // Set the width of the Line Renderer
         line.startColor = Color.cyan;
         line.material = material;
         line.startWidth = 0.05F;
         // Set the number of vertex fo the Line Renderer
         line.positionCount = 2;
     }
     
     // Update is called once per frame
     void Update () {
         // Check if the GameObjects are not null
         if (!drawn && gameObject1 != null && gameObject2 != null)
         {
             // Update position of the two vertex of the Line Renderer
             Vector3 pos = gameObject1.transform.position;
             pos.z = 5;
             line.SetPosition(0, pos);
             pos = gameObject2.transform.position;
             pos.z = 5;
             line.SetPosition(1, pos);
             
             drawn = true;
         }
     }
 }