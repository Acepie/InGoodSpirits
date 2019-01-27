using UnityEngine;

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
        routineToDo.AddAction(new Wait(.1f));
        routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
        routineToDo.AddAction(new UseElevator(this, Floor.Ground));
        routineToDo.AddAction(new MoveTo(new Vector2(20, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
        routineToDo.AddAction(new Wait(.5f));
        routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
        routineToDo.AddAction(new UseElevator(this, Floor.Second));
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
      door.GetComponent<Door>().OpenDoor();
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