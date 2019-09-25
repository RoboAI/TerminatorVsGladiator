using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyContinuousTimer : MonoBehaviour
{
    public delegate void TimerElapsedCallback(long millis);

    private Coroutine coroutine = null;

    public void StartTimer(float seconds, TimerElapsedCallback t)
    {
        Debug.Log("StartContinousTimer");
        coroutine = StartCoroutine(StartContinuousCoroutine(seconds, t));
    }

    public void StopTimer()
    {
        Debug.Log("StopContinuousTimer");
        StopCoroutine(coroutine);
    }

    private IEnumerator StartContinuousCoroutine(float seconds, TimerElapsedCallback t)
    {
        Debug.Log("StartContinousCoroutine");

        long timeElapsed = 0;

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        while (true)
        {
            sw.Start();
            yield return new WaitForSeconds(seconds);
            sw.Stop();

            timeElapsed += sw.ElapsedMilliseconds;

            t?.Invoke(timeElapsed);
        }
    }
}
