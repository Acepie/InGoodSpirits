using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
  private Text timeText;

  private const float START_DISPLAY_HOUR = 7;
  // Start is called before the first frame update
  void Awake()
  {
    timeText = gameObject.GetComponent<Text>();
  }

  // Update is called once per frame
  void Update()
  {
    string gameTime = GameTimeToTimeString();
    timeText.text = gameTime;
  }

  private string GameTimeToTimeString()
  {
    float gameTime = TimeManager.timeToGameTime();

    float hours_val = Mathf.Floor(gameTime) + TimeText.START_DISPLAY_HOUR;
    string m = "AM";
    if (hours_val == 12)
    {
      m = "PM";
    }
    if (hours_val > 12)
    {
      hours_val -= 12;
      m = "PM";
    }
    string hours = hours_val.ToString();


    float minutes_amount = (gameTime - Mathf.Floor(gameTime)) * 60;

    string minutes = minutes_amount.ToString();
    if (minutes_amount < 10)
    {
      minutes = "0" + minutes;
    }
    if (minutes.Length > 2)
    {
      minutes = minutes.Substring(0, 2);
    }

    return hours + ":" + minutes + " " + m;

  }
}
