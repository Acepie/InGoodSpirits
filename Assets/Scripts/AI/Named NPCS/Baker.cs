using UnityEngine;

public class Baker : NPC
{


    new void Awake()
    {
        base.Awake();
        currentFloor = Floor.Second;
        homeFloor = Floor.Second;

    }
    // Use this for initialization
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

    private void SetRoutine()
    {
        routineToDo.AddAction(new Wait(.25f));
        routineToDo.AddAction(new EnableItem(itemToCreate));
        routineToDo.AddAction(new Wait(.25f));
        routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
        routineToDo.AddAction(new UseElevator(this, Floor.Ground));
        routineToDo.AddAction(new MoveTo(new Vector2(20, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
        routineToDo.AddAction(new Wait(.3f));
        routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
        routineToDo.AddAction(new UseElevator(this, Floor.Second));
        routineToDo.AddAction(new MoveTo(GameObject.Find("Baker Room Waypoint").transform.position, this));
    }

}