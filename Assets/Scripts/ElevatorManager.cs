using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
  public List<Elevator> elevatorPositions = new List<Elevator>();

  public Vector2 GetDestinationPosition(Floor f)
  {
    return elevatorPositions[(int)f].transform.position;
  }
}
