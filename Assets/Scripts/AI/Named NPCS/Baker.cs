using UnityEngine;

public class Baker : NPC
{

  new void Awake()
  {
    base.Awake();
  }
  // Use this for initialization
  private void Start()
  {
    SetRoutine();
    StartRoutine();
  }

  private void Update()
  {
    if (!routines.isActioning)
    {
      StartRoutine();
    }
  }

  private void SetRoutine()
  {
    routines.AddAction(new Wait(.25f));
    routines.AddAction(new EnableItem(itemToCreate));
    routines.AddAction(new Wait(.25f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
    routines.AddAction(new UseElevator(this, Floor.Ground));
    routines.AddAction(new MoveTo(new Vector2(15, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routines.AddAction(new Wait(.3f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routines.AddAction(new UseElevator(this, Floor.Second));
    routines.AddAction(new MoveTo(new Vector2(-9, elevatorManager.GetDestinationPosition(Floor.Second).y), this));
  }
}