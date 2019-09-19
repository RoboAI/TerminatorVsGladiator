using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudlefttoright : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetTransformX(float n)
    {
        transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < 45)
            transform.Translate(0.1f, 0, 0);
        else
            SetTransformX(-57.0f);
    }
}
