﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Routine : MonoBehaviour
{

  [SerializeField] Queue<IAction> actions = new Queue<IAction>();
  IEnumerator actionCoroutine;
  IEnumerator routineCoroutine;
  public bool isActioning = false;

  public void AddAction(IAction a)
  {
    actions.Enqueue(a);
  }

  public Queue<IAction> GetActions()
  {
    return actions;
  }

  public void Start()
  {
    routineCoroutine = DoActions();
    StartCoroutine(routineCoroutine);
  }

  public IEnumerator DoActions()
  {
    isActioning = true;
    foreach (IAction a in actions)
    {
      actionCoroutine = a.DoAction();
      yield return StartCoroutine(actionCoroutine);
    }
    isActioning = false;
  }
}
