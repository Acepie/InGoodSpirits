using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeRoutine : ChangeRoutine
{

  public TestChangeRoutine(NPC npc, List<IAction> actions)
  {
    this.npc = npc;
    this.actions = actions;
  }

  protected override bool shouldChange()
  {
    return true;
  }
}