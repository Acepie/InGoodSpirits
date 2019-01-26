using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{

  private const int NUM_HOURS = 16;

  private const float SECONDS_PER_HOUR = 45;

  // Converts the time in seconds from unity to our game time, in hours.
  public float timeToGameTime()
  {
    return Time.time / SECONDS_PER_HOUR;
  }

  // Converts an amount of in game time to real world seconds
  public static float gameTimeToTime(float gameTime)
  {
    return gameTime * SECONDS_PER_HOUR;
  }
}
