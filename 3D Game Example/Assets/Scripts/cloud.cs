using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update

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
        if (transform.position.x < 45)
        {
            transform.Translate(speed, 0, 0);
        }
        else
        {
            speed = FloatFromArray.GetNextFloat();
            SetTransformX(-57.0f);
        }
        
    }
}
