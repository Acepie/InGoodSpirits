using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbstractInteractable : MonoBehaviour, PlayerInteractable
{
  protected bool mouseOver = false;

  public virtual void OnInteract(Player n)
  {
    throw new System.NotImplementedException();
  }

  private void OnMouseEnter()
  {
    //TODO: Swap sprites or toggle glow effect
    //Will action interactable objects glow? Probs
    mouseOver = true;
  }

  private void OnMouseExit()
  {
    mouseOver = false;
  }
}
