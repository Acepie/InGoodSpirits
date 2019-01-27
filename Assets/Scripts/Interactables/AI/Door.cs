using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  public float doorOpenSpeed;
  Rigidbody2D rb2d;
  protected float distTraveled;
  public float maxDistMoved = 2f;
  protected Vector2 startTransformPos;
  protected bool doorOpening = false;
  public AudioClip clipToPlay;

  private void Awake()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    if (doorOpening && CalcDistanceTraveled() > maxDistMoved)
    {
      doorOpening = false;
      rb2d.velocity = Vector2.zero;
      distTraveled = 0;

    }
  }

  protected virtual bool CheckOpenDoor(Collider2D collision)
  {
    return collision.tag == "NPC" && !doorOpening;
  }

  private float CalcDistanceTraveled()
  {
    return Vector2.Distance(startTransformPos, transform.position);
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

  public IEnumerator CloseDoorCoroutine()
  {
    doorOpening = true;
    startTransformPos = transform.position;
    rb2d.velocity = new Vector2(0, -doorOpenSpeed);
    yield return new WaitForSeconds(3f);
    doorOpening = false;
  }

  IEnumerator OpenDoorCoroutine()
  {
    doorOpening = true;
    startTransformPos = transform.position;
    rb2d.velocity = new Vector2(0, doorOpenSpeed);
    yield return new WaitForSeconds(1.25f);
    doorOpening = false;
    yield return CloseDoorCoroutine();
  }

  protected virtual void OnTriggerStay2D(Collider2D collision)
  {
    if (CheckOpenDoor(collision))
    {
      OpenDoor();
    }
  }
}
