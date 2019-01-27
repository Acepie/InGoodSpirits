using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableItem : IAction
{
    public GameObject itemToEnable;
    public AudioClip clipToPlay;

    public EnableItem(GameObject g)
    {
        itemToEnable = g;
        clipToPlay = itemToEnable.GetComponent<PickupInteractable>().onPickupClip;
        Debug.Log(itemToEnable.name);
    }

    public void SetItem(GameObject i)
    {
        itemToEnable = i;
    }
    public IEnumerator DoAction()
    {
        Debug.Log(Time.time);
        itemToEnable.GetComponent<Collider2D>().enabled = true;
        itemToEnable.GetComponent<SpriteRenderer>().enabled = true;
        SoundManager.PlaySound(clipToPlay);
        yield return null;
    }
}
