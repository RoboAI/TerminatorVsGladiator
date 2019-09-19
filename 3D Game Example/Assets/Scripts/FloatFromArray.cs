using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatFromArray : MonoBehaviour
{
    // Start is called before the first frame update
    static public float[] CloudSpeeds = new float[] { 0.15f, 0.2f, 0.3f, 0.35f, 0.4f, 0.45f, 0.25f };

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
