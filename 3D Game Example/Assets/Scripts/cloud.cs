using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxLeft = -20.75f;
    public float maxRight = 10.75f;

    Random random = new Random();
    float speed = 0;

    void Start()
    {
        speed = FloatFromArray.GetNextFloat();
    }

    void SetTransformX(float n)
    {
        transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < maxRight)
        {
            transform.Translate(speed, 0, 0);
        }
        else
        {
            speed = FloatFromArray.GetNextFloat();
            SetTransformX(maxLeft);
        }
        
    }
}
