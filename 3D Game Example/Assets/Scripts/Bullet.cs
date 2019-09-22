using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float time;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Seconds();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void Seconds()
    {
        time = time + Time.fixedDeltaTime;
        if (time > 0.1f)
        {
            time = 0.0f;
            rb.AddForce(0, speed, 0);
        }
    }
}
