using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public List<Elevator> elevatorPositions = new List<Elevator>();

    private void Awake()
    {
        if (elevatorPositions.Count < 3)
        {
            Debug.Log("Add more elevators to the manager!");
        }
    }

    public Vector2 GetDestinationPosition(Floor f)
    {
        Vector2 position = elevatorPositions[(int)f].transform.position;
        position.y = position.y + 0.15f;
        return position;
    }
}