using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float doorOpenSpeed;
    Rigidbody2D rb2d;
    protected float distTraveled;
    public float maxDistMoved = 4f;
    protected Vector2 startTransformPos;
    protected bool doorOpening = false;
    public AudioClip clipToPlay;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected virtual bool CheckOpenDoor(Collider2D collision)
    {
        return collision.tag == "NPC" && !doorOpening;
    }

    public void OpenDoor()
    {
        if (!doorOpening)
        {
            IEnumerator cor = OpenDoorCoroutine();
            SoundManager.PlaySound(clipToPlay);
            StartCoroutine(cor);
        }
    }

    IEnumerator OpenDoorCoroutine()
    {
        doorOpening = true;
        startTransformPos = transform.position;
        rb2d.velocity = new Vector2(0, doorOpenSpeed);
        yield return new WaitForSeconds(.2f);
        rb2d.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(.5f);
        startTransformPos = transform.position;
        rb2d.velocity = new Vector2(0, -doorOpenSpeed);
        yield return new WaitForSeconds(.2f);
        rb2d.velocity = new Vector2(0, 0);
        doorOpening = false;
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (CheckOpenDoor(collision))
        {
            OpenDoor();
        }
    }
}