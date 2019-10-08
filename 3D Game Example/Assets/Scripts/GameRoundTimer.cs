using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameRoundTimer : MonoBehaviour
{
    private MyCountdownTimer.TimerFinished finishedCallback;
    private MyCountdownTimer.TimerElapsedCallback intervalCallback;

    private int roundTime;
    private int timeRemaining;

    public bool isRoundStarted = false;

    TextMeshProUGUI timeDisplay;
    GameObject countdownImagesGroup;
    MyCountdownTimer countdownTimer;
    MyContinuousTimer continuousTimer;

    private void Awake()
    {
        //roundTime = GameObject.Find("Controller").GetComponent<Controller>().roundTimeInSeconds;

        countdownTimer = GetComponent<MyCountdownTimer>();
        continuousTimer = GetComponent<MyContinuousTimer>();
        timeDisplay = GetComponent<TextMeshProUGUI>();
        //countdownImagesGroup = 
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundStarted)
        {

        }
    }

    public void StartRound(int seconds, MyCountdownTimer.TimerFinished tf)
    {
        StartRound(seconds, null, tf);
    }

    public void StartRound(int seconds,MyCountdownTimer.TimerElapsedCallback te, MyCountdownTimer.TimerFinished tf)
    {
        if(!isRoundStarted)
        {
            Debug.Log("start round");
            roundTime = seconds;

            finishedCallback = tf;
            intervalCallback = te;

            timeRemaining = roundTime;
            isRoundStarted = true;

            //timeDisplay.enabled = true;//works: shows the display
            timeDisplay.SetText((timeRemaining).ToString());

            countdownTimer.StartTimer(timeRemaining, 1, 1, TimerElapsed, TimerFinished);
        }
    }

    public void TimerElapsed(long millis)
    {
        //Debug.Log("timer elapsed");
        timeDisplay.SetText((--timeRemaining).ToString());
        intervalCallback?.Invoke(millis);
    }

    public void TimerFinished()
    {
        finishedCallback?.Invoke();
        isRoundStarted = false;
    }


    public void StartFinalCountDown(int seconds, MyCountdownTimer.TimerElapsedCallback te, MyCountdownTimer.TimerFinished tf)
    { 
    //timeDisplay.enabled = false;//works: hides the display
      // StartRound(seconds, te, )
    }

    public void FinalSecondsInterval(long millis)
    {
    }

    public void FinalEndedCall()
    {
        isRoundStarted = false;
    }

    public void Stop()
    {
        countdownTimer.StopTimer();
    }
}
