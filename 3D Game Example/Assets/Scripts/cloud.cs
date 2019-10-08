using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public float maxLeft = -20.75f;
    public float maxRight = 10.75f;
    float speed = 0;
    float cloudYPos = 0;

    void Start()
    {
        RandomiseCloud();
    }

     void FixedUpdate()
    {
        //if cloud.x is still less than right
        if (transform.position.x < maxRight)
            transform.Translate(speed, 0, 0);
        else
            RandomiseCloud();
    }

    void RandomiseCloud()
    {
        speed = NextSpeedFloat();
        cloudYPos = NextYPositionFloat();
        transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
    }

    float NextSpeedFloat()
    {
        return Random.Range(0.015f, 0.045f);
    }

    float NextYPositionFloat()
    {
        return Random.Range(3.6f, 8.0f);
    }
}
