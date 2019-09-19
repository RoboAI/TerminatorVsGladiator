using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJiggle
{

    public float jiggleHalfPeriod { get; set; }

    private float timeElapsed;
    private float currentJiggle;
    private bool IsToJiggle;
    private bool IsScalingUp;
    private Vector3 vScaleUpSpeed;
    private Vector3 vScaleDownSpeed;

    public float speed;



    public PlayerJiggle()
    {
        Initialise();
    }

    public PlayerJiggle(float jiggleDuration)
    {
        Initialise();

        jiggleHalfPeriod = jiggleDuration / 2;
    }

    private void Initialise()
    {
        timeElapsed = 0;
        currentJiggle = 0;
        IsScalingUp = true;
        IsToJiggle = false;
        speed = 0.1f;
        vScaleUpSpeed = new Vector3(1 + speed, 1 + speed, 1 + speed);
        vScaleDownSpeed = new Vector3(speed - 1, speed - 1, speed - 1);
    }

    public void Start()
    {
        timeElapsed = 0;
        currentJiggle = 0;

        vScaleUpSpeed = new Vector3(1 + speed, 1 + speed, 1 + speed);
        vScaleDownSpeed = new Vector3(speed - 1, speed - 1, speed - 1);

        IsScalingUp = true;
        IsToJiggle = true;
    }

    public void FixedUpdate(GameObject gameObject, float time)
    {
        if (!IsToJiggle)
            return;

        
    }
}
