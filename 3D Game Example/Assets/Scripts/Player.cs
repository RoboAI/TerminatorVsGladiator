using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    int maxJumpCount = 3;

    // Start is called before the first frame update
    public Rigidbody rb;

    //private bool isJumpPressed = false;
    //private bool isLeftPressed = false;
    //private bool isRightPressed = false;

    private KeyCode KeyLeft = KeyCode.A;
    private KeyCode KeyRight = KeyCode.D;
    private KeyCode KeyJump = KeyCode.W;
    private KeyCode KeyFire = KeyCode.Space;

    private float moveSpeed = 5.0f;

    private float time = 0.0f;
    private int hasJumped = 0;
    private float jiggleAmount = 1.5f;

    private MaterialPropertyBlock materialBlock;
    private Renderer renderer;
    Color colourOriginal;
    Color colourSeverlyDamaged;
    Color colourCurrent;

    private float health = 1.0f;

    GameObject Ground;
    GameObject thisObject;

    void Start()
    {
        renderer = GetComponent<Renderer>();

        colourOriginal = renderer.material.color;
        colourSeverlyDamaged = Color.red;
        
        rb = GetComponent<Rigidbody>();
        Ground = GameObject.Find("GroundPlane");
        thisObject = GameObject.Find(this.name);

        materialBlock = new MaterialPropertyBlock();

        //FallFaster();
    }

    void Update()
    {
        //isJumpPressed = Input.GetKeyDown(KeyCode.W);
        //isLeftPressed = Input.GetKey(KeyCode.A);
        //isRightPressed = Input.GetKey(KeyCode.D);

        DoKeyEvents();
    }

    void OnGUI()
    {
        GUILayout.Label((KeyLeft == KeyCode.A).ToString());
    }

    void FixedUpdate()
    {

        if (hasJumped > 0 && rb.velocity.y <= 100)
        {
            FallFaster();
        }
    }

    private void TenSeconds()
    {
        time = time + Time.fixedDeltaTime;
        if (time > 10.0f)
        {
            time = 0.0f;
        }
    }

    public void AssignKeys(KeyCode left, KeyCode right, KeyCode jump, KeyCode fire)
    {
        KeyLeft = left;
        KeyRight = right;
        KeyJump = jump;
        KeyFire = fire;
    }

    public void DoKeyEvents()
    {
        DoKeyEvents(KeyJump, Input.GetKeyDown(KeyJump));
        DoKeyEvents(KeyLeft, Input.GetKey(KeyLeft));
        DoKeyEvents(KeyRight, Input.GetKey(KeyRight));
        DoKeyEvents(KeyFire, Input.GetKey(KeyFire));
    }

   // public void DoKeyEvents(bool isJumpPressed, bool isLeftPressed, bool isRightPressed, bool isFirePressed)
    public void DoKeyEvents(KeyCode key, bool isPressed)
    {
        //Debug.Log(key.ToString());

        if (key == KeyJump && isPressed)
        {
            Debug.Log("key JUMP");
            if (hasJumped < maxJumpCount)
            {
                Jump();
                hasJumped++;
            }
        }

        else if (key == KeyLeft && isPressed)
        {
            Debug.Log("key left");
            //rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            rb.AddForce(-moveSpeed, 0, 0, ForceMode.VelocityChange);
        }

        else if (key == KeyRight && isPressed)
        {
            Debug.Log("key right");
            //rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            rb.AddForce(moveSpeed, 0, 0, ForceMode.VelocityChange);
        }

        else if(key == KeyFire && isPressed)
        {
            Debug.Log("key fire");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //dont move in the z direction
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        if (collision.gameObject.name == "GroundPlane")
        {
            //Debug.Log("Touched Ground");
            hasJumped = 0;
        }

        else if(collision.gameObject.name.StartsWith("Player_"))
        {
            PlayerHit(collision);
        }
    }

    public void FallFaster()
    {
        //Debug.Log("FallFaster");
        rb.AddForce(0, -5.0f, 0, ForceMode.VelocityChange);

        //rb.AddForce(0, -100.0f, 0, ForceMode.Acceleration);
    }

    private void StopJump()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void Jump()
    {
        //rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(0, 80.0f, 0, ForceMode.Impulse);
        //rb.AddForce(0, -800.0f, 0, ForceMode.Acceleration);
        Jiggle();
    }

    private void Bounce()
    {
        rb.velocity = new Vector3(0, 80, 0);
    }

    private void BounceSmall()
    {
        rb.velocity = new Vector3(0, 10, 0);
    }

    protected void PlayerHit(Collision collision)
    {
        health -= 0.1f;
        if (health <= 0)
            health = 1.0f;

        colourCurrent = Color.Lerp(colourSeverlyDamaged, colourOriginal, health);
        materialBlock.SetColor("_Color", colourCurrent);
        renderer.SetPropertyBlock(materialBlock);
        Stopwatch stopwatch = new Stopwatch();
        Jiggle();
    }

    protected void Jiggle()
    {
        iTween.PunchScale(thisObject, new Vector3(jiggleAmount, jiggleAmount, jiggleAmount), 0.5f);
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