﻿using UnityEngine;

public class Florist : NPC
{
  bool isHome = true;
  public GameObject THISISMYDOOR;
  new protected void Awake()
  {
    if (THISISMYDOOR == null)
    {
      Debug.Log("ATTACH THE DOOR OBJECT TO THE FLORIST!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }
    base.Awake();
    // List<IAction> testActions = new List<IAction>();
    // testActions.Add(new MoveTo(new Vector2(5, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    // testActions.Add(new MoveTo(new Vector2(15, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));

    routines.AddAction(new Wait(1f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.First), this));
    routines.AddAction(new UseElevator(this, Floor.Ground));
    routines.AddAction(new MoveTo(new Vector2(5, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    // routines.AddAction(new TestChangeRoutine(this, testActions));
    routines.AddAction(new MoveTo(new Vector2(15, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routines.AddAction(new Wait(.5f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routines.AddAction(new UseElevator(this, Floor.First));
    routines.AddAction(new MoveTo(new Vector2(-9, elevatorManager.GetDestinationPosition(Floor.First).y), this));
  }

  private void Update()
  {
    if (!routines.isActioning)
    {
      StartRoutine();
    }

  }
  public void OnDoorBellRang()
  {
    if (isHome)
    {
      THISISMYDOOR.GetComponent<Door>().OpenDoor();
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Floorist Door")
    {
      isHome = !isHome;
    }
  }
}