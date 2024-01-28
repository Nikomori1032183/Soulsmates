using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VInspector;
using static InputHandler;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TurnHandler turnHandler;

    [SerializeField] float timerLength = 10.0f;
    float timeLeft;
    float hourCounter;
    [SerializeField] int dayTime = 0;
    [SerializeField] int day = 0;
    int seconds;

    bool timerActive;

    public delegate void TimerDelegate();

    public static event TimerDelegate OnTimerEnd;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();

        timeLeft = timerLength;
        timerActive = true;

        TurnHandler.OnTurnChange += NewTimer;
        TextBox.OnOpen += PauseTimer;
        TextBox.OnExit += StartTimer;
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
            PauseTimer();
            //pop up a confirmation menu for changing player
            turnHandler.ChangeTurn(); //change turn
            //NewTimer();
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

        timerText.text = "Day " + day + "\n" + dayTime + ":" + Mathf.Round(hourCounter);
    }

    public void NewTimer()
    {
        timeLeft = timerLength;
        StartTimer();
    }
    public void EndTimer()
    {
        OnTimerEnd?.Invoke();
        timerActive = false;
        timeLeft = 0.0f;
        
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void PauseTimer()
    {
        timerActive = false;
    }

    public void WipeTimer()
    {
        timerActive = false;
        timeLeft = timerLength;
        day = 0;
        dayTime = 0;
        hourCounter = 0;
    }

    public int GetDay()
    {
        return day;
    }
}
