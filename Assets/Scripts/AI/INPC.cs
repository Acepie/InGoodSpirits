using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPC  {
    void SetVelocity(Vector3 vel);
    void AddAction(IAction a);
    void SetPos(Vector3 v);
}
