using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    float time;

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
        if (collision.gameObject.name == "Player_1")
        {
            //Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), collision.collider);
        }
        else
            Destroy(this.gameObject);
    }

    private void Seconds()
    {
        time = time + Time.fixedDeltaTime;
        if (time > 0.1f)
        {
            time = 0.0f;
            rb.AddForce(0, -500, 0);
        }
    }
}
