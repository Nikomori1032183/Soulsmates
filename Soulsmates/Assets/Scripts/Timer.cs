using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;

    [SerializeField] float timerLength = 120.0f;
    float timeLeft;
    float hourCounter;
    [SerializeField] int dayTime = 0;
    [SerializeField] int day = 0;
    int seconds = 36;

    bool timerActive;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        ResetTimer();
        StartTimer();
    }

    void Update()
    {
        //timeLength minute timer
        if (timeLeft > 0 && timerActive)
        {
            timeLeft -= Time.deltaTime;
            hourCounter += Time.deltaTime;

        }
        if (timeLeft <= 0)
        {
            Debug.Log("Ran Out of time!");
            //end player turn and reset timer
        }
        if (hourCounter >= 60)
        {
            hourCounter = 0;
            dayTime++;
        }
        if (dayTime == 8)
        {
            day++;
            dayTime = 0;
        }
        timerText.text = "Day " + day + "\n" + dayTime + ":" + seconds;
    }

    void ResetTimer()
    {
        timeLeft = timerLength;
    }

    void StartTimer()
    {
        timerActive = true;
    }

    void EndTimer()
    {
        timerActive = false;
        timeLeft = 0.0f;
    }

    void PauseTimer(bool pause)
    {
        if (pause)
        {
            timerActive = false;
        }
        else
        {
            timerActive = true;
        }
    }
}
