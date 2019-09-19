using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;


    private bool isJumpPressed = false;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;

    private float moveSpeed = 5.0f;

    private float time = 0.0f;
    private bool hasJumped = false;

    private MaterialPropertyBlock materialBlock;
    private Renderer renderer;
    Color colourOriginal;
    Color colourSeverlyDamaged;
    Color colourCurrent;

    private float health = 1.0f;

    GameObject Ground;


    void Start()
    {
        renderer = GetComponent<Renderer>();

        colourOriginal = renderer.material.color;
        colourSeverlyDamaged = Color.red;
        //colourCurrent = new Color(colourOriginal.r, colourOriginal.g, colourOriginal.b);
        

        rb = GetComponent<Rigidbody>();
        Ground = GameObject.Find("GroundPlane");

        materialBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        isJumpPressed = Input.GetKeyDown(KeyCode.W);
        isLeftPressed = Input.GetKey(KeyCode.A);
        isRightPressed = Input.GetKey(KeyCode.D);
    }

    void FixedUpdate()
    {

        if (isJumpPressed)
        {
            if (!hasJumped)
            {
                Jump();
                hasJumped = true;
            }
        }

        if (isLeftPressed)
        {
            //rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            rb.AddForce(-moveSpeed, 0, 0, ForceMode.VelocityChange);
        }

        if (isRightPressed)
        {
            //rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            rb.AddForce(moveSpeed, 0, 0, ForceMode.VelocityChange);
        }

        if (hasJumped && rb.velocity.y <= 4)
        {
            FallFaster();
        }

        time = time + Time.fixedDeltaTime;
        if (time > 10.0f)
        {
            time = 0.0f;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GroundPlane")
        {
            //Bounce();
            PlayerHit(collision);

            hasJumped = false;
        }
    }

    private void FallFaster()
    {
        rb.AddForce(0, -4.0f, 0, ForceMode.VelocityChange);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(0, 80, 0);
    }

    private void Bounce()
    {
        rb.velocity = new Vector3(0, 80, 0);
    }

    private void BounceSmall()
    {
        rb.velocity = new Vector3(0, 80, 0);
    }

    protected void PlayerHit(Collision collision)
    {
        health -= 0.1f;
        if (health <= 0)
            health = 1.0f;
        Debug.Log(health);

        colourCurrent = Color.Lerp(colourSeverlyDamaged, colourOriginal, health);
        materialBlock.SetColor("_Color", colourCurrent);
        renderer.SetPropertyBlock(materialBlock);
    }
}

//if (isMoving && hasJumped)
//{
//    // when the cube has moved for 10 seconds, report its position
//    time = time + Time.fixedDeltaTime;
//    if (time > 10.0f)
//    {
//        Debug.Log(gameObject.transform.position.y + " : " + time);
//        time = 0.0f;
//    }
//}


//if (isJumpPressed)
//{
//    // the cube is going to move upwards in 10 units per second
//    rb.velocity = new Vector3(0, 20, 0);
//    hasJumped = true;
//    Debug.Log("jump");
//}

//if (hasJumped)
//{
//    Debug.Log("has jumped");
//    // when the cube has moved for 10 seconds, report its position
//    time = time + Time.fixedDeltaTime;
//    if (time > 10.0f)
//    {
//        Debug.Log(gameObject.transform.position.y + " : DSFGDFGDFG " + time);
//        time = 0.0f;
//    }

//    Transform tGround = Ground.transform;
//    if (transform.position.y <= transform.position.y)
//    {
//        rb.velocity = new Vector3(0, 0, 0);
//        hasJumped = false;
//    }
//}


//Vector3 position = this.transform.position;
//position.x -= moveSpeed;
//this.transform.position = position;