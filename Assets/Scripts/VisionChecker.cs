using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionChecker : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D myCol;
    [SerializeField]
    private Sprite alerted_sprite;
    [SerializeField]
    private Sprite suspicious_sprite;
    [SerializeField]
    private NPC parent_Script;

    void OnTriggerStay2D(Collider2D col)
    {
       if (col.tag != "Player")  { return; }
       Player player = col.gameObject.GetComponent<Player>();

       if (!player.isDiscoverable)
       {
         float x_dist = col.gameObject.transform.position.x - gameObject.transform.position.x;
         if (x_dist > 0 )
         {
            parent_Script.SetEmote(suspicious_sprite, true);
         }
         else 
         {
            parent_Script.SetEmote(alerted_sprite, true);
         }
       }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        parent_Script.SetEmoteVisibility(false);
    }
}
