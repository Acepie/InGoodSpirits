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
      if (npc.routines.isActioning)
      {
        npc.routines.StopActions();
      }
      npc.routines.ClearActions();
      foreach (var action in actions)
      {
        npc.routines.AddAction(action);
      }
      npc.routines.Start();
    }

    yield return null;
  }

  protected abstract bool shouldChange();
}