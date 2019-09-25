using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameRoundTimer : MonoBehaviour
{
    private MyCountdownTimer.TimerFinished callback;

    private int roundTime;
    private int timeRemaining;

    public bool isStartRound = false;

    TextMeshProUGUI timeDisplay;
    MyCountdownTimer countdownTimer;
    MyContinuousTimer continuousTimer;

    private void Awake()
    {
        //roundTime = GameObject.Find("Controller").GetComponent<Controller>().roundTimeInSeconds;

        countdownTimer = GetComponent<MyCountdownTimer>();
        continuousTimer = GetComponent<MyContinuousTimer>();
        timeDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartRound)
        {
            Debug.Log("start round");
            timeRemaining = roundTime;
            timeDisplay.SetText(timeRemaining.ToString());
            countdownTimer.StartTimer(timeRemaining, 1, 1, TimerElapsed, TimerFinished);
            isStartRound = false;
        }
    }

    public void StartRound(int seconds, MyCountdownTimer.TimerFinished tf)
    {
        roundTime = seconds;
        callback = tf;
        isStartRound = true;
    }

    public void TimerElapsed(long millis)
    {
        Debug.Log("timer elapsed");

        timeDisplay.SetText((--timeRemaining).ToString());
    }

    public void TimerFinished()
    {
        callback?.Invoke();
    }
}
