using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivedCookiesRoutine : Routine
{

    public static Queue<IAction> MakeRoutine(NPC n)
    {
        Queue<IAction> res = new Queue<IAction>();
        res.Enqueue(new Wait(0.05f));
        res.Enqueue(new MoveTo(Vector2.zero, n, "we're going to the elevator bois"));
        res.Enqueue(new UseElevator(n, Floor.Second));
        res.Enqueue(new MoveTo(GameObject.Find("Baker Room Waypoint").transform.position, n));
        res.Enqueue(new Wait(.2f));

        foreach(IAction a in n.ReturnHomeRoutine(Floor.Second))
        {
            res.Enqueue(a);
        }

        return res;
    }

}
