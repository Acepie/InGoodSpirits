using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

  public float doorOpenSpeed;
  Rigidbody2D rb2d;
  private float distTraveled;
  public float maxDistMoved = 2f;
  private Vector2 startTransformPos;
  bool doorOpening = false;

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

  private float CalcDistanceTraveled()
  {
    return Vector2.Distance(startTransformPos, transform.position);
  }

  public void OpenDoor()
  {
    if (!doorOpening)
    {
      IEnumerator cor = OpenDoorCoroutine();
      StartCoroutine(cor);
    }
  }

  public IEnumerator CloseDoorCoroutine()
  {
    doorOpening = true;
    startTransformPos = transform.position;
    rb2d.velocity = new Vector2(0, -doorOpenSpeed);
    yield return new WaitForSeconds(3f);
  }

  IEnumerator OpenDoorCoroutine()
  {
    doorOpening = true;
    startTransformPos = transform.position;
    rb2d.velocity = new Vector2(0, doorOpenSpeed);
    yield return new WaitForSeconds(1.25f);
    yield return CloseDoorCoroutine();
  }

  void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<NPC>() != null)
    {
      if (!doorOpening)
      {
        /*IEnumerator cor = OpenDoorCoroutine();
        StartCoroutine(cor);*/
        OpenDoor();
      }
    }
  }
}
