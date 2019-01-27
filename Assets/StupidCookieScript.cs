using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dumb bakers cookies are in a room
/// </summary>
public class StupidCookieScript : MonoBehaviour
{
    public NPC npc;
    private bool cookiesReceived = false;
    private void Awake()
    {
        if (npc == null)
        {
            Debug.Log("SET NPC FOR STUPID COOKIE HAPPINESS");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!cookiesReceived && collision.tag == "Cookie")
        {
            npc.AddFriends(GameObject.Find("Baker").GetComponent<Baker>());
            npc.SetNextRoutine(ReceivedCookiesRoutine.MakeRoutine(npc));
            cookiesReceived = true;
        }
    }
}
