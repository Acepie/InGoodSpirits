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
    [SerializeField]
    private Sprite happyFace;

    //Checks for player specific detection.  set to true if you want the npc to detect 
    private bool is_playerDetectable = true;

    void OnTriggerStay2D(Collider2D col)
    {
       if (col.tag.Equals("Player"))  
       {
        Player player = col.gameObject.GetComponent<Player>();

        if (is_playerDetectable && !player.isDiscoverable)
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
       else  if (col.tag.Equals("NPC"))
       {
           //We're checking if we're friendly
           NPC otherNPC = col.gameObject.transform.parent.gameObject.GetComponent<NPC>();

           if (parent_Script.AreWeFriends(otherNPC))
           {
                parent_Script.SetEmote(happyFace, true);
           }
       }
    }

    public void SetPlayerDetectable(bool i_detectable)
    {
        is_playerDetectable = i_detectable;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        parent_Script.SetEmoteVisibility(false);
    }
}
