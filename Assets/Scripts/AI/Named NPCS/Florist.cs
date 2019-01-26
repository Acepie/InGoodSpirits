using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Florist : NPC
{
  ElevatorManager elevatorManager;

  new protected void Awake()
  {
    base.Awake();
    elevatorManager = GameObject.FindGameObjectWithTag("Elevator Manager").GetComponent<ElevatorManager>();
    Loop();
    Loop();
  }

  void Loop()
  {
    routines.AddAction(new Wait(.1f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
    routines.AddAction(new UseElevator(this, Floor.Ground));
    routines.AddAction(new MoveTo(new Vector2(15, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routines.AddAction(new Wait(.5f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routines.AddAction(new UseElevator(this, Floor.Second));
    routines.AddAction(new MoveTo(new Vector2(-9, elevatorManager.GetDestinationPosition(Floor.Second).y), this));
  }
}
