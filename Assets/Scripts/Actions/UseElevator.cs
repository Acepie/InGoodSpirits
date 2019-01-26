using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Floor
{
  Ground = 0,
  First = 1,
  Second = 2
}

public class UseElevator : IAction
{

  INPC n;
  Floor destFloor;
  ElevatorManager elevatorManager = GameObject.FindGameObjectWithTag("Elevator Manager").GetComponent<ElevatorManager>();

  public UseElevator(INPC n_, Floor dest)
  {
    destFloor = dest;
    n = n_;
  }

  public IEnumerator DoAction()
  {
    n.SetPos(elevatorManager.GetDestinationPosition(destFloor));
    yield return null;
  }
}
