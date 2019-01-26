using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class MoveTo : IAction
{
  public Vector2 destination;
  IEnumerator moveCoroutine;
  NPC n;

  public MoveTo(Vector2 d, NPC n_)
  {
    destination = d;
    n = n_;
  }

  IEnumerator IAction.DoAction()
  {
    //manage our NPC's facing direction
    bool X_dist =  destination.x > n.gameObject.transform.position.x;
    n.direction = X_dist? NPC.FacingDirection.RIGHT : NPC.FacingDirection.LEFT;
    
    return Move(destination);
  }

  private IEnumerator Move(Vector2 destination)
  {
    float dist = Vector2.Distance(n.GetPos(), destination);
    while (dist > 0.1)
    {
      Vector2 dir = destination - n.GetPos();
      n.SetVelocity(dir.normalized * n.speed);
      dist = Vector2.Distance(n.transform.position, destination);
      yield return null;
    }
    n.SetVelocity(Vector2.zero);
    yield return null;
  }
}
