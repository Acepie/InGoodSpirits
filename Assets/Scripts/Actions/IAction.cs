using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAction {

    IEnumerator DoAction();
    bool IsPerformingAction();
}
