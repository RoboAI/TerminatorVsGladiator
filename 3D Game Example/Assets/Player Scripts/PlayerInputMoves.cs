using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMoves : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public Rigidbody rb;
    private PlayerInputs playerInputs;
    private ConstantForce cf;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInputs>();
        cf = GetComponent<ConstantForce>();
    }

    void Update()
    {
        if (playerInputs.isLeftPressed)
            DoLeft();
        else if (playerInputs.isRightPressed)
            DoRight();
    }

    private void FixedUpdate()
    {
        
    }

    private void DoLeft()
    {
        cf.force = Vector3.left * moveSpeed;
        rb.AddForce(Vector3.left, ForceMode.Impulse);
    }

    private void DoRight()
    {
        cf.force = Vector3.right * moveSpeed;
        rb.AddForce(Vector3.right, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}


