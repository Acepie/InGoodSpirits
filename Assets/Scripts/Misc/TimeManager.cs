using UnityEngine;

public class TimeManager
{
  private static float startTime = 0f;
  private const int NUM_HOURS = 12;

  private const float SECONDS_PER_HOUR = 3;

  public static void ResetTime()
  {
    startTime = Time.time;
  }

  // Converts the time in seconds from unity to our game time, in hours.
  public static float timeToGameTime()
  {
    return (Time.time - startTime) / SECONDS_PER_HOUR;
  }

  // Converts an amount of in game time to real world seconds
  public static float gameTimeToTime(float gameTime)
  {
    return gameTime * SECONDS_PER_HOUR;
  }

  public static bool gameEnded()
  {
    return timeToGameTime() > NUM_HOURS;
  }
}