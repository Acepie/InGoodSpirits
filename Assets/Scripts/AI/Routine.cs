using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Routine : MonoBehaviour
{

  [SerializeField] Queue<IAction> actions = new Queue<IAction>();
  IEnumerator actionCoroutine;
  IEnumerator routineCoroutine;

  public void AddAction(IAction a)
  {
    actions.Enqueue(a);
  }

  public Queue<IAction> GetActions()
  {
    return actions;
  }

  private void Start()
  {
    StartCoroutine(DoActions());
  }

  public IEnumerator DoActions()
  {
    foreach (IAction a in actions)
    {
      actionCoroutine = a.DoAction();
      yield return StartCoroutine(actionCoroutine);
    }
  }
}
