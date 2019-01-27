using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableItem : IAction
{
    public GameObject[] itemToEnable;
    public GameObject prefabToCreate;
    Vector3 locationToMakeItem;

  public EnableItem(GameObject[] g)
  {
    itemToEnable = g;
  }

    public EnableItem(GameObject g, Vector3 pos)
    {
        prefabToCreate = g;
        locationToMakeItem = pos;
        itemToEnable = new GameObject[0];
    }

  public IEnumerator DoAction()
  {
        if(itemToEnable.Length > 0)
        {
            foreach (GameObject item in itemToEnable)
            {
                item.GetComponent<Collider2D>().enabled = true;
                item.GetComponent<SpriteRenderer>().enabled = true;
                SoundManager.PlaySound(item.GetComponent<PickupInteractable>().clipToPlay);
            }
        }
        else
        {
            GameObject newItem = Object.Instantiate(prefabToCreate) as GameObject;
            newItem.transform.position = locationToMakeItem;
        }

    yield return null;
  }
}
