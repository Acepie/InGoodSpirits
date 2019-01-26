using System.Collections;
using UnityEngine;

/// <summary>
/// In game time
/// </summary>
public class Wait : IAction
{
    private float time;

    public Wait(float gameTime)
    {
        time = TimeManager.gameTimeToTime(gameTime);
    }

    public IEnumerator DoAction()
    {
        yield return new WaitForSeconds(time);
    }
}