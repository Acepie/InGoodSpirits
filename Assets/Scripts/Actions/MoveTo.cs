using System.Collections;
using UnityEngine;

[SerializeField]
public class MoveTo : IAction
{
    public Vector2 destination;
    private IEnumerator moveCoroutine;
    private NPC n;

    public MoveTo(Vector2 d, NPC n_)
    {
        destination = d;
        n = n_;
    }

    public void SetDestination(Vector2 dest)
    {
        destination = dest;
    }

    IEnumerator IAction.DoAction()
    {
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