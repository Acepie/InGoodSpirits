using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Routine : MonoBehaviour
{
    [SerializeField] private Queue<IAction> actions = new Queue<IAction>();
    private IEnumerator actionCoroutine;
    private IEnumerator routineCoroutine;
    public bool isActioning = false;

    public void AddAction(IAction a)
    {
        actions.Enqueue(a);
    }

    public Queue<IAction> GetActions()
    {
        return actions;
    }

    public void SetActions(Queue<IAction> r)
    {
        actions = r;
    }

    public void ClearActions()
    {
        actions.Clear();
    }

    public void StopActions()
    {
        StopCoroutine(routineCoroutine);
    }

    public void StartRoutine()
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
        GetComponent<NPC>().GetNextRoutine();
    }
}