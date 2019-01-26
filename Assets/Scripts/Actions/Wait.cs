using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : IAction
{
  float time;

  public Wait(float gameTime)
  {
    time = TimeManager.gameTimeToTime(gameTime);
  }

  public IEnumerator DoAction()
  {
    yield return new WaitForSeconds(time);
  }
}