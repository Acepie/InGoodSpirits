using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloristDoor : Door
{
    protected override bool CheckOpenDoor(Collider2D collision)
    {
        Debug.Log("Floral");
        return collision.tag == "NPC" && collision.name != "Lover" && !doorOpening;
    }
}
