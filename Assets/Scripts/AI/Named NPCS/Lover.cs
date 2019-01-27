using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lover : NPC {
    /*
     * Routine: Chill, Go to lover's room, lack courage to ring. go back to his room. be sad. Be sad
     * */

    public AudioClip source;
    public Sprite sadEmote;
     
    new protected void Awake()
    {
        base.Awake();
        currentFloor = Floor.First;
        homeFloor = Floor.First;
  
    }

    private void SetRoutine()
    {
        //chill
        routineToDo.AddAction(new Wait(.25f));
        //Go To lover's room
        routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.First), this));
        routineToDo.AddAction(new UseElevator(this, Floor.Second));
        routineToDo.AddAction(new MoveTo(GameObject.Find("Florist Room Dest").transform.position, this));
        routineToDo.AddAction(new Wait(.1f));
        routineToDo.AddAction(new DoEmote(sadEmote, source, this, 3));

        //Go back to his room
        routineToDo.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
        routineToDo.AddAction(new UseElevator(this, Floor.First));
        routineToDo.AddAction(new MoveTo(GameObject.FindGameObjectWithTag("L_Waypoint").transform.position, this));
    }

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

}
