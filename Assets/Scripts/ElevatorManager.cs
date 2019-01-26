using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
  public List<Elevator> elevatorPositions = new List<Elevator>();

    private void Awake()
    {
        if(elevatorPositions.Count < 3)
        {
            Debug.Log("Add more elevators to the manager!");
        }
    }

    public Vector2 GetDestinationPosition(Floor f)
  {
    return elevatorPositions[(int)f].transform.position;
  }
}
