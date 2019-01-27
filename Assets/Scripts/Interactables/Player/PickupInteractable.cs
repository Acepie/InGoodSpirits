﻿using UnityEngine;

public class PickupInteractable : MonoBehaviour, PlayerInteractable
{
  private Vector3 startScale;
    public AudioClip clipToPlay;


  public virtual void OnInteract(Player p)
  {
    p.PickUp(this);
    startScale = transform.localScale;
    transform.parent = p.transform;
    transform.localScale = new Vector3(.85f * transform.localScale.x, .85f * transform.localScale.y, 1);

  }

  public virtual void Drop(Vector3 v)
  {
    transform.parent = null;
    transform.localScale = startScale;
  }
}