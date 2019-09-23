using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatFromArray : MonoBehaviour
{
    // Start is called before the first frame update
    static public float[] CloudSpeeds = new float[] { 0.015f, 0.02f, 0.03f, 0.035f, 0.04f, 0.045f, 0.025f };

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public float GetNextFloat()
    {
        int f = Random.Range(0, CloudSpeeds.Length);
        return CloudSpeeds[f];
    }
}
