﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, INPC
{

  public float speed;
  Rigidbody2D rb2d;
  IEnumerator coroutine;
  public Routine routines;

  [SerializeField]
  public SpriteRenderer EmoteSlot;
  protected ElevatorManager elevatorManager;


  protected void Awake()
  {
    rb2d = GetComponent<Rigidbody2D>();
    routines = GetComponent<Routine>();
    elevatorManager = GameObject.FindGameObjectWithTag("Elevator Manager").GetComponent<ElevatorManager>();
    EmoteSlot.enabled = false;
  }

  public void SetVelocity(Vector2 vel)
  {
    rb2d.velocity = vel;
  }

  public void AddAction(IAction a)
  {
    routines.AddAction(a);
  }

  public Vector2 GetPos()
  {
    return transform.position;
  }

  public void SetPos(Vector2 v)
  {
    transform.position = v;
  }
}
