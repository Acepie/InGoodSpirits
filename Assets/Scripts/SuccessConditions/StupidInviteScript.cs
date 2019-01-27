using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidInviteScript : MonoBehaviour
{
    public static int numInvitesReceived = 0;
    static bool bakerReceived = false;
    static bool floristReceived = false;
    static bool loverReceived = false;
    static bool guardReceived = false;
    public NPC baker;
    public NPC florist;
    public NPC guard;
    public NPC musician;
    public NPC lover;

    private void Awake()
    {
        baker = GameObject.Find("Baker").GetComponent<Baker>();
        florist = GameObject.Find("Florist").GetComponent<Florist>();
        musician = GameObject.Find("Musician").GetComponent<Musician>();
        guard = GameObject.Find("Security Guard").GetComponent<SecurityGuard>();
        lover = GameObject.Find("Lover").GetComponent<Lover>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Invites")
        {
            if (this.tag == "Lover Room")
            {
                loverReceived = true;
                SoundManager.OnSuccess(NPCClass.Lover);
                lover.AddFriends(musician);
                Debug.Log("lover");
            }
            if (this.tag == "Baker Room")
            {
                bakerReceived = true;
                SoundManager.OnSuccess(NPCClass.Baker);
                baker.AddFriends(musician);
                Debug.Log("bak");
            }

            if (this.tag == "Florist Room")
            {
                floristReceived = true;
                SoundManager.OnSuccess(NPCClass.Florist);
                florist.AddFriends(musician);
                Debug.Log("flor");
            }

            if (this.tag == "Lobby Room")
            {
                SoundManager.OnSuccess(NPCClass.Guard);
                guardReceived = true;
                guard.AddFriends(musician);
                Debug.Log("guard");
            }
        }

    }
}
