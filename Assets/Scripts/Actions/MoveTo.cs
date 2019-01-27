using System.Collections;
using UnityEngine;

[SerializeField]
public class MoveTo : IAction
{
  public Vector2 destination;
  protected IEnumerator moveCoroutine;
  protected NPC n;
    private ElevatorManager elevatorManager = GameObject.FindGameObjectWithTag("Elevator Manager").GetComponent<ElevatorManager>();

    public MoveTo(Vector2 d, NPC n_)
  {
    destination = d;
    n = n_;
  }

    /// <summary>
    /// Sets destination as elevator on same floor
    /// </summary>
    /// <param name="d"></param>
    /// <param name="n_"></param>
    /// <param name="s"></param>
public MoveTo(Vector2 d, NPC n_, string s)
{
        destination = elevatorManager.GetDestinationPosition(n_.homeFloor);
        Debug.Log(destination);
        n = n_;
}

    public IEnumerator DoAction()
  {
    //manage our NPC's facing direction
    bool X_dist = destination.x > n.gameObject.transform.position.x;
    n.direction = X_dist ? NPC.FacingDirection.RIGHT : NPC.FacingDirection.LEFT;

    return Move(destination);
  }

    protected IEnumerator Move(Vector2 destination)
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