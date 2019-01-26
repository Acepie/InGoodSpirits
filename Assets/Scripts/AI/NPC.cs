﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, INPC
{
  public float speed;
  private Rigidbody2D rb2d;
  private IEnumerator coroutine;
  public Routine routines;

  [SerializeField]
  public SpriteRenderer EmoteSlot;

  public HashSet<NPC> friendSet;

  protected ElevatorManager elevatorManager;

  protected void Awake()
  {
    rb2d = GetComponent<Rigidbody2D>();
    routines = GetComponent<Routine>();
    EmoteSlot.enabled = false;
    elevatorManager = GameObject.FindGameObjectWithTag("Elevator Manager").GetComponent<ElevatorManager>();
    friendSet = new HashSet<NPC>();
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

  public void SetEmote(Sprite new_Sprite, bool setVisible = false)
  {
    EmoteSlot.sprite = new_Sprite;
    if (setVisible)
    {
      EmoteSlot.enabled = true;
    }
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
}
