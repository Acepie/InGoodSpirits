using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableItem : IAction
{
  public GameObject[] itemToEnable;

  public EnableItem(GameObject[] g)
  {
    itemToEnable = g;
  }

  public void SetItem(GameObject[] i)
  {
    itemToEnable = i;
  }
  public IEnumerator DoAction()
  {
    foreach (GameObject item in itemToEnable)
    {
      item.GetComponent<Collider2D>().enabled = true;
      item.GetComponent<SpriteRenderer>().enabled = true;
      SoundManager.PlaySound(item.GetComponent<PickupInteractable>().clipToPlay);
    }
    yield return null;
  }
}
