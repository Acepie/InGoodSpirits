using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionChecker : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D myCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if (col.tag != "Player")  { return; }
       Player player = col.gameObject.GetComponent<Player>();
       if (!player) {Debug.Log("Excuse me how does a player not have a player script");}

       if (!player.isDiscoverable) 
       {
         float x_dist = col.gameObject.transform.position.x - gameObject.transform.position.x;
         Debug.Log(x_dist);
         if (x_dist > 0 )
         {
             Debug.Log("you be far");
         }
         else 
         {
             Debug.Log("They be seeing you");
         }
       }
    }
}
