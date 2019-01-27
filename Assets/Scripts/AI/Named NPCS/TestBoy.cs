using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoy : NPC
{

  // Use this for initialization
  new protected void Awake()
  {
    base.Awake();

    routineToDo.AddAction(new MoveTo(new Vector2(-3, 6), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new UseElevator(this, Floor.Ground));
    routineToDo.AddAction(new MoveTo(new Vector2(3, -4.78f), this));
  }
}
