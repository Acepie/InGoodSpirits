using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : AbstractInteractable
{
    public override void OnInteract(INPC n)
    {
        n.AddAction(new UseElevator(n, Floor.Ground));
    }

}
