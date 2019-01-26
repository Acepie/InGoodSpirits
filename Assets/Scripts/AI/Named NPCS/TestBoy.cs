using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoy : NPC
{

  // Use this for initialization
  protected void Awake()
  {
    base.Awake();
    routines.AddAction(new MoveTo(new Vector2(-3, 6), this));
    routines.AddAction(new UseElevator(this, Floor.Ground));
    routines.AddAction(new MoveTo(new Vector2(0, -4.78f), this));
  }
}
