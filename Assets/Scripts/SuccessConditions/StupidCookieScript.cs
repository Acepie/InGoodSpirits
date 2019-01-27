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
    public GameObject cookies;
    public Sprite cookiesEatenSprite;
    public AudioClip cookieMuncher;
    AudioSource playsound;
    private void Awake()
    {
        playsound = GetComponent<AudioSource>();
        if (npc == null)
        {
            Debug.Log("SET " + this.name + " FOR STUPID COOKIE HAPPINESS");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!cookiesReceived && collision.tag == "Cookie")
        {
            npc.AddFriends(GameObject.Find("Baker").GetComponent<Baker>());
            npc.SetNextRoutine(ReceivedCookiesRoutine.MakeRoutine(npc));
            cookiesReceived = true;
            cookies = collision.gameObject;
        }

        Debug.Log(npc.name);

        if(cookiesReceived && collision.GetComponent<NPC>() == npc)
        {
            playsound.Play();
            cookies.GetComponent<SpriteRenderer>().sprite = cookiesEatenSprite;
        }
    }

}
