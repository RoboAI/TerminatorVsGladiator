using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCountdownTimer : MonoBehaviour
{
    //callbacks for timer events
    public delegate void TimerElapsedCallback(long millis);
    public delegate void TimerFinished();

    //to stop the Coroutine
    private Coroutine coroutine = null;

    //start timer for seconds with default parameters
    public void StartTimer(float delayInSeconds, TimerElapsedCallback t, TimerFinished tf)
    {
        Debug.Log("StartTimer");
        coroutine = StartCoroutine(StartCountdownCoroutine(delayInSeconds, delayInSeconds, delayInSeconds, t, tf));
    }

    //start timer with full customisable
    public void StartTimer(float startValue, float waitForDelay, float countDownBy, TimerElapsedCallback t, TimerFinished tf)
    {
        Debug.Log("StartTimer2");
        coroutine = StartCoroutine(StartCountdownCoroutine(startValue, waitForDelay, countDownBy, t, tf));
    }

    public void StopTimer()
    {
        if (coroutine == null)
            return;

        StopCoroutine(coroutine);
        coroutine = null;
    }

    //the coroutine thats actually run
    private IEnumerator StartCountdownCoroutine(float startValue, float waitForDelay, float countDownBy, TimerElapsedCallback t, TimerFinished tf)
    {
        Debug.Log("StartCountdownCoroutine");

        //stopwatch to track time elapsed
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        while (startValue > 0)
        {
            sw.Start();

            yield return new WaitForSeconds(waitForDelay);

            //update 'time-remaining'
            startValue -= countDownBy;

            sw.Stop();

            //callback for interval
            t?.Invoke(sw.ElapsedMilliseconds);
        }

        //callback for end of timer
        tf?.Invoke();

        Debug.Log("Timer finished " + sw.ElapsedMilliseconds);
    }
}
