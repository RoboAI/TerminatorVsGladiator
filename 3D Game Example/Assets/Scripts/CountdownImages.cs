using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CountdownImages : MonoBehaviour
{
    SpriteRenderer[] sprites;

    MyCountdownTimer timer;

    MyCountdownTimer.TimerFinished finishedCallback;

    int currentFrame;
    bool isStarted = false;

    void Awake()
    {
        timer = GetComponent<MyCountdownTimer>();

        sprites = new SpriteRenderer[10];
        for(int i = 1; i <= sprites.Length; i++)
        {
            sprites[i-1] = GameObject.Find("count_" + i).GetComponent<SpriteRenderer>();
            sprites[i-1].enabled = false;
        }
    }

    public void StartCountdown(int from, MyCountdownTimer.TimerFinished tf)
    {
        currentFrame = from - 1;
        sprites[currentFrame].enabled = true;
        finishedCallback = tf;
        isStarted = true;
        timer.StartTimer(from, 1, 1, OnCountdownInterval, OnTimerFinished);
    }

    void OnCountdownInterval(long millis)
    {
        sprites[currentFrame].enabled = false;
        if(currentFrame > 0){
            currentFrame--;
            sprites[currentFrame].enabled = true;
        }
    }

    void OnTimerFinished()
    {
        finishedCallback?.Invoke();
    }

    public void Stop()
    {
        timer.StopTimer();
    }
}
