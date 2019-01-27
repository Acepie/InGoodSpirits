﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCClass
{
  Baker,
  Florist,
  Guard,
  Lover,
  Musician
}

public class NPC : MonoBehaviour, INPC
{

  public enum FacingDirection { RIGHT, LEFT };
    protected bool swapNextRoutine = false;
    public Floor homeFloor;

  public float speed;
  Rigidbody2D rb2d;
  IEnumerator coroutine;
    protected Queue<IAction> normalRoutine = new Queue<IAction>();
    public Routine routineToDo;
    protected Queue<IAction> nextRoutine = new Queue<IAction>();
  [SerializeField]
  public SpriteRenderer EmoteSlot;
    [SerializeField]
  public HashSet<NPC> friendSet;
  public GameObject[] itemToCreate;
  public Animator anim;
    public Floor currentFloor;

  public ElevatorManager elevatorManager;
  public FacingDirection direction = FacingDirection.RIGHT;

  protected void Awake()
  {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
    routineToDo = GetComponent<Routine>();
    elevatorManager = GameObject.FindGameObjectWithTag("Elevator Manager").GetComponent<ElevatorManager>();
    friendSet = new HashSet<NPC>();
    SetEmoteSlot();

  }

  protected void SetEmoteSlot()
  {
    if (EmoteSlot == null)
    {
      foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
      {
        if (sr.tag == "Emote Tag")
        {
          EmoteSlot = sr;
        }
      }
    }
  }

  public void SetVelocity(Vector2 vel)
  {
    rb2d.velocity = vel;
  }

  public void AddAction(IAction a)
  {
    routineToDo.AddAction(a);
  }

  public Vector2 GetPos()
  {
    return transform.position;
  }

  public void SetPos(Vector2 v)
  {
    transform.position = v;
  }

  public void SetEmote(Sprite new_Sprite, bool setVisible = false)
  {
    EmoteSlot.sprite = new_Sprite;
    if (setVisible)
    {
      EmoteSlot.enabled = true;
    }
  }

  protected void StartRoutine()
  {
        routineToDo.StartRoutine();
  }

  public void SetEmoteVisibility(bool i_visible)
  {
    EmoteSlot.enabled = i_visible;
  }

  /**Adds the given NPC to our friends list. Note that we add them for BOTH people*/
  public void AddFriends(NPC newFriend)
  {
    friendSet.Add(newFriend);
    newFriend.friendSet.Add(this);
  }

  public bool AreWeFriends(NPC npc)
  {
    return friendSet.Contains(npc);
  }

    public void SetFloor(Floor f)
    {
        currentFloor = f;
    }
  

    public void SetNextRoutine(Queue<IAction> r)
    {
        nextRoutine = r;
        swapNextRoutine = true;

    }

    public virtual void GetNextRoutine()
    {
        Debug.Log("next routine for " + this.name);
        if (swapNextRoutine)
        {
            routineToDo.SetActions(nextRoutine);
            swapNextRoutine = false;
        }
        else
        {
            routineToDo.SetActions(normalRoutine);
        }
    }
}
