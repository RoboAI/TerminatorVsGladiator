using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    // Start is called before the first frame update
    float x = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x += 0.01f;

        transform.Rotate(0, 0, 1.0f); //rotates 50 degrees per second around z axis
    }
}
