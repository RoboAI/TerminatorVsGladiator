using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    static public float damageAmount = 0.025f;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
