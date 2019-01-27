using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableItem : IAction
{
  public GameObject[] itemToEnable;

  public EnableItem(GameObject[] g)
  {
    itemToEnable = g;
    foreach (GameObject item in itemToEnable)
    {
      Debug.Log(item.name);
    }
  }

  public void SetItem(GameObject[] i)
  {
    itemToEnable = i;
  }
  public IEnumerator DoAction()
  {
    Debug.Log(Time.time);
    foreach (GameObject item in itemToEnable)
    {
      Debug.Log(item.name + "ENABLED!");
      item.GetComponent<Collider2D>().enabled = true;
      item.GetComponent<SpriteRenderer>().enabled = true;
      SoundManager.PlaySound(item.GetComponent<AudioSource>());
    }
    yield return null;
  }
}
