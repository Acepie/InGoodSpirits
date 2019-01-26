using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, AIInteractable
{
  public void OnInteract(INPC n)
  {
    n.AddAction(new UseElevator(n, Floor.Ground));
  }

}
