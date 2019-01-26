using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private const int NUM_HOURS = 16;

    private bool is_TimeUp = false;

    private const float SECONDS_PER_HOUR = 45;

    /*iterates from 1 to NUM_Hours.  Note that even though it is an int, actions can be scheduled for hour 3.5, for example */
    private int CurrentHour = 0;

    // Update is called once per frame
    void Update()
    {
    
     CurrentHour =  (int) Mathf.Floor(timeToGameTime(Time.time));
 
    }

    /**Converts the time in seconds from unity to our game time, in hours.   */
    public float timeToGameTime(float i_currTime)
    { 
        return i_currTime/TimeManager.SECONDS_PER_HOUR;
    }
}
