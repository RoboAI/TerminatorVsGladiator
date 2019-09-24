using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    private PlayerInputs playerInputs;

    public int maxJumpCount = 1;
    public float jumpForce = 13;
    public float velocityModulus = 5f;

    public int hasJumped = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInputs>();
    }

    private void OnGUI()
    {
        //GUILayout.Label(hasJumped.ToString());
    }

    private void FixedUpdate()
    {
        TryJump();
        ApplyExtraForce();
    }

    public void TryJump()
    {
        if (playerInputs.isJumpPressed && hasJumped < maxJumpCount)
            Jump();
    }

    public void Jump()
    {
        //Debug.Log("PlayerJump JUMPPPPPPP");
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        hasJumped++;
    }

    public void ApplyExtraForce()
    {
        rb.AddForce(Vector3.down * (jumpForce - rb.velocity.y) * velocityModulus, ForceMode.Acceleration);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            if (playerInputs.isJumpPressed)
                Jump();
            else
                hasJumped = 0;
        }

        else if (collision.gameObject.tag == "Player")
        {
            hasJumped = 0;
        }
    }
}
