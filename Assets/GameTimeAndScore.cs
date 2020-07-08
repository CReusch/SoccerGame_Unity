using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameTimeAndScore : MonoBehaviour
{
    public Text ScoreText;
    public Text TimerText;

    public int TimerInSeconds = 60;

    private float StartTime = 0;

    private bool TimerEnded = false;
    private int Score = 0;
    private bool Debugging = true;

    private void Start()
    {
        TimerText.text = "Time left : " + GetTimeDisplay(TimerInSeconds);
        StartTime = Time.time;
        TimerEnded = false;
    }

    private void Update()
    {
        if(Time.time - StartTime < TimerInSeconds)
        {
            TimerText.text = "Time left : " + GetTimeDisplay(TimerInSeconds - Time.time - StartTime);
        }
        else
        {
            TimerText.text = "Time left : 0:00";
            TimerEnded = true;
            ScoreText.color = Color.red;
            TimerText.color = Color.red;
        }
    }

    public void IncrementScore()
    {
        if (!TimerEnded)
        {
            Score++;
            ScoreText.text = "Score : " + Score;
            if (Debugging)
                Debug.Log("Score in time");
        }
        else
        {
            if (Debugging)
                Debug.Log("Score after time");
        }
        
    }

    private string GetTimeDisplay(float timeToShow)
    {
        int SecondsToShow = Mathf.CeilToInt(timeToShow);
        int Seconds = SecondsToShow % 60;
        string SecondsWithZero = "";

        if (Seconds < 10)
            SecondsWithZero = "0" + Seconds;
        else
            SecondsWithZero = Seconds.ToString();

        int Minutes = (SecondsToShow - Seconds) / 60;

        return Minutes + ":" + SecondsWithZero;
    }
}
