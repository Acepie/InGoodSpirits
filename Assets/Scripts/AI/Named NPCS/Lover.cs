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
        //chill
        routines.AddAction(new Wait(1f));
        //Go To lover's room
        routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.First), this));
        routines.AddAction(new UseElevator(this, Floor.Second));
        routines.AddAction(new MoveTo(GameObject.FindGameObjectWithTag("Florist Door").transform.position, this));
        routines.AddAction(new Wait(.25f));
        routines.AddAction(new DoEmote(sadEmote, source, this, 3));
        

        //Go back to his room
        routines.AddAction(new MoveTo(elevatorManager.GetDestinationPosition(Floor.Second), this));
        routines.AddAction(new UseElevator(this, Floor.First));
        routines.AddAction(new MoveTo(GameObject.FindGameObjectWithTag("L_Waypoint").transform.position, this));
    }

}
