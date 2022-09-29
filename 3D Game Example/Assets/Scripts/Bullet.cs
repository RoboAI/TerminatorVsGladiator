using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    static public float damageAmount = 0.025f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            return;
        if (collision.gameObject.tag == "Platform")
            return;

        if (collision.gameObject.tag != "Bullet") 
        {
            Debug.Log("Bullet collision");
            Destroy(this.gameObject);
        }
    }
}
