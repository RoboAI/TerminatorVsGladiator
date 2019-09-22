using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private KeyCode KeyLeft = KeyCode.A;
    private KeyCode KeyRight = KeyCode.D;
    private KeyCode KeyJump = KeyCode.W;
    private KeyCode KeyFire = KeyCode.Space;

    public bool isJumpPressed = false;
    public bool isLeftPressed = false;
    public bool isRightPressed = false;
    public bool isFirePressed = false;

    void Start()
    {
    }

    void Update()
    {
        GetRealInputs();
    }

    private void GetRealInputs()
    {
        isJumpPressed = Input.GetKeyDown(KeyJump);
        isLeftPressed = Input.GetKey(KeyLeft);
        isRightPressed = Input.GetKey(KeyRight);
        isFirePressed = Input.GetKeyDown(KeyFire);
    }

    public void AssignKeys(KeyCode left, KeyCode right, KeyCode jump, KeyCode fire)
    {
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
