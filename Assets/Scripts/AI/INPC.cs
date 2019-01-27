using UnityEngine;

public interface INPC
{
    void SetVelocity(Vector2 vel);

    void AddAction(IAction a);

    void SetPos(Vector2 v);
    void SetFloor(Floor f);
}