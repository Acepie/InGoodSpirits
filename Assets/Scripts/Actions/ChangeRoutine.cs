using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChangeRoutine : IAction
{
  protected List<IAction> actions;
  protected NPC npc;

  public IEnumerator DoAction()
  {
    if (shouldChange())
    {
      if (npc.routineToDo.isActioning)
      {
        npc.routineToDo.StopActions();
      }
      npc.routineToDo.ClearActions();
      foreach (var action in actions)
      {
        npc.routineToDo.AddAction(action);
      }
      npc.routineToDo.StartRoutine();
    }
    yield return null;
  }

  protected abstract bool shouldChange();
}