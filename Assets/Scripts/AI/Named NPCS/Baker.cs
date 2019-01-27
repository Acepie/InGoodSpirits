using UnityEngine;

public class Baker : NPC
{
  public GameObject cookiePrefab;
  public Vector3 cookieSpawn;

  new void Awake()
  {
    base.Awake();
    currentFloor = Floor.Second;
    homeFloor = Floor.Second;

  }
  // Use this for initialization
  private void Start()
  {
    SetDefaultRoutine();
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

  /// <summary>
  /// Default Routine: Go out to store. Come back. Make cookies. Repeat
  /// </summary>
  private void SetDefaultRoutine()
  {
    routineToDo.ClearActions();
    //Go out to store
    routineToDo.AddAction(new Wait(.25f));
    routineToDo.AddAction(new MoveTo(new Vector2(-5.7f, elevatorManager.GetDestinationPosition(Floor.Second).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
    routineToDo.AddAction(new UseElevator(this, Floor.Ground));
    routineToDo.AddAction(new MoveTo(new Vector2(4.5f, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(new Vector2(20, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.5f));

    //Come back from store
    routineToDo.AddAction(new MoveTo(new Vector2(5.8f, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routineToDo.AddAction(new UseElevator(this, Floor.Second));
    routineToDo.AddAction(new MoveTo(new Vector2(-4.7f, elevatorManager.GetDestinationPosition(Floor.Second).y), this));
    routineToDo.AddAction(new Wait(.1f));
    routineToDo.AddAction(new MoveTo(GameObject.Find("Baker Room Waypoint").transform.position, this));
    //Make cookies
    routineToDo.AddAction(new EnableItem(cookiePrefab, cookieSpawn));
    routineToDo.AddAction(new Wait(.25f));
  }

}