using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMoves : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public Rigidbody rb;
    private PlayerInputs playerInputs;
    private ConstantForce cf;
    private PlayerJump playerJump;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInputs>();
        cf = GetComponent<ConstantForce>();
        playerJump = GetComponent<PlayerJump>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        //Debug.Log("2nd: " + Time.time);
        if (playerInputs.isLeftPressed)
            DoLeft();
        if (playerInputs.isRightPressed)
            DoRight();
        if (playerInputs.isJumpPressed)
            DoJump();
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

    private void DoJump()
    {
        playerJump.TryJump();
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}


