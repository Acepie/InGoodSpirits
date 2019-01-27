using System.Collections;
using UnityEngine;

public enum Floor
{
    Ground = 0,
    First = 1,
    Second = 2
}

public class UseElevator : IAction
{
    private INPC n;
    private Floor destFloor;
    private ElevatorManager elevatorManager = GameObject.FindGameObjectWithTag("Elevator Manager").GetComponent<ElevatorManager>();


    public UseElevator(INPC n_, Floor dest)
    {
        destFloor = dest;
        n = n_;
    }

    public IEnumerator DoAction()
    {
        yield return new WaitForSeconds(TimeManager.gameTimeToTime(.05f));
        n.SetPos(elevatorManager.GetDestinationPosition(destFloor));
        n.SetFloor(destFloor);
        yield return null;
    }
}