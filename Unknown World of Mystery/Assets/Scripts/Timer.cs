using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text time;

    private float seconds;
    private int minutes;
    private int hours;

    private bool isPause;

    private void Start()
    {
        isPause = false;   
    }

    private void Update()
    {
        if(!isPause)
        {
            seconds += Time.deltaTime;
            if(seconds >= 60)
            {
                minutes++;
                seconds = 0;
            }
            if(minutes == 60)
            {
                hours++;
                minutes = 0;
            }
            time.text = String.Format("{0}:{1}:{2}", hours, minutes, (int)seconds);
        }
    }

    public void StartTimer()
    {
        string[] time = GameManager.timeInTheGame.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        seconds = float.Parse(time[0]);
        minutes = int.Parse(time[1]);
        hours = int.Parse(time[2]);
        isPause = false;
    }
}
