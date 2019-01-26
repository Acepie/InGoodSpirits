using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class MoveTo : IAction
{ 
    public Vector3 destination;
    bool isMoving = false;
    IEnumerator moveCoroutine;
    NPC n;
    

    public MoveTo(Vector3 d, NPC n_)
    {
        destination = d;
        n = n_;
    }

    public void SetDestination(Vector3 dest)
    {
        destination = dest;
    }

    IEnumerator IAction.DoAction()
    {
        return Move(destination);
    }

    private IEnumerator Move(Vector3 destination)
    {
        isMoving = true;
        Vector2 dir = destination - n.transform.position;
        float dist = Vector2.Distance(n.transform.position, destination);
        while (dist > 0.1)
        {
            Debug.Log(dist);
            n.SetVelocity(dir.normalized * n.speed);
            dist = Vector2.Distance(n.transform.position, destination);
            yield return null;
        }
        n.SetVelocity(Vector2.zero);
        isMoving = false;
        yield return null;
    }

    public bool IsPerformingAction()
    {
        return isMoving;
    }
}
