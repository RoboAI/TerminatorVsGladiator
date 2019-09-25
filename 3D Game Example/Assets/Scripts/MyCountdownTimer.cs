using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCountdownTimer : MonoBehaviour
{
    public delegate void TimerElapsedCallback(long millis);
    public delegate void TimerFinished();

    private Coroutine coroutine = null;

    public void StartTimer(float delayInSeconds, TimerElapsedCallback t, TimerFinished tf)
    {
        Debug.Log("StartCountdown");
        coroutine = StartCoroutine(StartCountdownCoroutine(delayInSeconds, delayInSeconds, delayInSeconds, t, tf));
    }

    public void StartTimer(float startValue, float waitForDelay, float countDownBy, TimerElapsedCallback t, TimerFinished tf)
    {
        Debug.Log("StartCountdown2");
        coroutine = StartCoroutine(StartCountdownCoroutine(startValue, waitForDelay, countDownBy, t, tf));
    }

    public void StopTimer()
    {
        if (coroutine == null)
            return;

        StopCoroutine(coroutine);
        coroutine = null;
    }

    private IEnumerator StartCountdownCoroutine(float startValue, float waitForDelay, float countDownBy, TimerElapsedCallback t, TimerFinished tf)
    {
        Debug.Log("StartCountdown");
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        while (startValue > 0)
        {
            sw.Start();

            yield return new WaitForSeconds(waitForDelay);
            startValue -= countDownBy;

            sw.Stop();

            t?.Invoke(sw.ElapsedMilliseconds);
        }

        tf?.Invoke();

        Debug.Log("Timer finished " + sw.ElapsedMilliseconds);
    }
}
