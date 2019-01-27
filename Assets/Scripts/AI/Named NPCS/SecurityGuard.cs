using System;
using UnityEngine;
using System.Collections.Generic;

public class SecurityGuard : NPC
{
    private int numWorking;
    private VisionChecker visionChecker;
    bool onAlert = true;
    Wait alertACtion = new Wait(1f);
    public Sprite sleepy;
    DoEmote notAlertAction;
    public SpriteRenderer vision;

    private new void Awake()
    {
        base.Awake();
        currentFloor = Floor.Ground;
        visionChecker = GetComponentInChildren<VisionChecker>();
        vision = GetComponentInChildren<VisionChecker>().GetComponent<SpriteRenderer>();
        notAlertAction  = new DoEmote(sleepy, this, 5f);
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

    private void SetRoutine()
    {
        routineToDo.AddAction(alertACtion);
    }

    public override void GetNextRoutine()
    {
        Debug.Log("next routine for " + this.name);
        if (swapNextRoutine)
        {
            routineToDo.SetActions(nextRoutine);
            swapNextRoutine = false;
        }
        else
        {
            onAlert = !onAlert;
            if (onAlert)
            {
                routineToDo.ClearActions();
                routineToDo.AddAction(alertACtion);
                visionChecker.GetComponent<Collider2D>().enabled = true;
                vision.enabled = true;
            }
            else
            {
                routineToDo.ClearActions();
                routineToDo.AddAction(notAlertAction);
                visionChecker.GetComponent<Collider2D>().enabled = false;
                vision.enabled = false;
            }
        }
    }
}