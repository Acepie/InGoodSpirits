﻿using UnityEngine;

public class Florist : NPC
{
  bool isHome = true;
  public GameObject door;
  new protected void Awake()
  {
    currentFloor = Floor.Second;
    homeFloor = Floor.Second;
    if (door == null)
    {
      Debug.Log("ATTACH THE DOOR OBJECT TO THE FLORIST!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }
    base.Awake();


  }

  private void SetRoutine()
  {
    routineToDo.AddAction(new Wait(1f));
    routineToDo.AddAction(new MoveTo(new Vector2(-0.9f, elevatorManager.GetDestinationPosition(Floor.Second).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
    routineToDo.AddAction(new UseElevator(this, Floor.Ground));

    //// routineToDo.AddAction(new MoveTo(new Vector2(4.5f, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.1f));

    routineToDo.AddAction(new MoveTo(new Vector2(20, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.5f));

    // routineToDo.AddAction(new MoveTo(new Vector2(5.8f, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    // routineToDo.AddAction(new Wait(.1f));

    routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routineToDo.AddAction(new UseElevator(this, Floor.Second));

    //routineToDo.AddAction(new MoveTo(new Vector2(-2.4f, elevatorManager.GetDestinationPosition(Floor.Second).y), this));
    // routineToDo.AddAction(new Wait(.1f));

    routineToDo.AddAction(new MoveTo(GameObject.Find("Florist Room Waypoint").transform.position, this));
  }

  private void Start()
  {
    SetRoutine();
    normalRoutine = routineToDo.GetActions();
    StartRoutine();
  }

  private void Update()
  {
    if (!routineToDo.isActioning)
    {
      StartRoutine();
    }
  }

  public void OnDoorBellRang()
  {
    if (isHome)
    {
      if (GameObject.Find("Lover").GetComponent<Lover>().atDoor)
      {
        AddFriends(GameObject.Find("Lover").GetComponent<Lover>());
        GameObject.Find("Lover").GetComponent<Lover>().hasBouquet = false;
        Debug.Log("LOVER AND FLORIST ARE FRIENDS");
      }
      door.GetComponent<Door>().OpenDoor();
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Florist Door")
    {
      isHome = !isHome;
    }
  }
}