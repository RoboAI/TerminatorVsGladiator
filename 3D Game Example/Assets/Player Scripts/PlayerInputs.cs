using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    //inputs can be customised for each player by assinging to these. Use AssignKeys();
    public KeyCode KeyLeft;
    public KeyCode KeyRight;
    public KeyCode KeyJump;
    public KeyCode KeyFire;

    //bools to keep track of key-presses
    public bool isJumpPressed = false;
    public bool isLeftPressed = false;
    public bool isRightPressed = false;
    public bool isFirePressed = false;

    Controller controller;

    private void Awake()
    {
        KeyLeft = KeyCode.A;
        KeyRight = KeyCode.D;
        KeyJump = KeyCode.W;
        KeyFire = KeyCode.Space;
        
        controller = GameObject.Find("Controller").GetComponent<Controller>();
    }

    void Start()
    {
    }

    void Update()
    {
        if(!controller.isGameEnded && !controller.isGamePaused)
            GetRealInputs();
        else{
            isJumpPressed = false;
            isLeftPressed = false;
            isRightPressed = false;
            isFirePressed = false;
        }
    }

    private void GetRealInputs()
    {
        isJumpPressed = Input.GetKey(KeyJump);
        isLeftPressed = Input.GetKey(KeyLeft);
        isRightPressed = Input.GetKey(KeyRight);
        isFirePressed = Input.GetKeyDown(KeyFire);
    }

    public void AssignKeys(KeyCode left, KeyCode right, KeyCode jump, KeyCode fire)
    {
        //Debug.Log("assign keys");
        KeyLeft = left;
        KeyRight = right;
        KeyJump = jump;
        KeyFire = fire;
    }

    public void KeyLeftDown()
    {
        isLeftPressed = true;
    }

    public void KeyRightDown()
    {
        isRightPressed = true;
    }

    public void KeyJumpDown()
    {
        isJumpPressed = true;
    }

    public void KeyFireDown()
    {
        isFirePressed = true;
    }

    public void KeyLeftUp()
    {
        isLeftPressed = false;
    }

    public void KeyRightUp()
    {
        isRightPressed = false;
    }

    public void KeyJumpUp()
    {
        isJumpPressed = false;
    }

    public void KeyFireUp()
    {
        isFirePressed = false;
    }
}
