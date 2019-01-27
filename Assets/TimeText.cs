﻿using System.Collections;
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


        float minutes_pct = gameTime - Mathf.Floor(gameTime);
       

        string minutes = (minutes_pct * 60).ToString().Substring(0,2);

        return hours + ":" + minutes + " " + m;

    }
}
