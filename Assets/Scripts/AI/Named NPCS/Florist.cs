using UnityEngine;

public class Florist : NPC
{
  new protected void Awake()
  {
    base.Awake();
    // List<IAction> testActions = new List<IAction>();
    // testActions.Add(new MoveTo(new Vector2(5, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    // testActions.Add(new MoveTo(new Vector2(15, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));

    routines.AddAction(new Wait(.1f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
    routines.AddAction(new UseElevator(this, Floor.Ground));
    routines.AddAction(new MoveTo(new Vector2(5, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    // routines.AddAction(new TestChangeRoutine(this, testActions));
    routines.AddAction(new MoveTo(new Vector2(15, elevatorManager.GetDestinationPosition(Floor.Ground).y), this));
    routines.AddAction(new Wait(.5f));
    routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Ground), this));
    routines.AddAction(new UseElevator(this, Floor.Second));
    routines.AddAction(new MoveTo(new Vector2(-9, elevatorManager.GetDestinationPosition(Floor.Second).y), this));
  }

  private void Update()
  {
    if (!routines.isActioning)
    {
      StartRoutine();
    }
  }
}