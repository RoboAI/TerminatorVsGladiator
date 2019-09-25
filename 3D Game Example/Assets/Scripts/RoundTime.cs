using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTime : MonoBehaviour
{
    private int roundTime;
    private int timeRemaining;

    public bool isPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        roundTime = GameObject.Find("Controller").GetComponent<Controller>().roundTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {

        }
    }
}
