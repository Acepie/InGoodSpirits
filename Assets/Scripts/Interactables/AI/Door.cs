using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    public float distTraveled;
    protected Vector2 startTransformPos;
    protected bool doorOpening = false;
    public AudioClip clipToPlay;

    protected Vector2 endTransformPos;

    private void Awake()
    {
        startTransformPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        endTransformPos = startTransformPos + new Vector2(0, distTraveled);


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
        rb2d.MovePosition(endTransformPos);
        yield return new WaitForSeconds(TimeManager.gameTimeToTime(.15f));
        rb2d.MovePosition(startTransformPos);
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