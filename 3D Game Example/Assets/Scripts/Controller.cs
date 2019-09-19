using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Player Player1;
    Player Player2;

    private bool isJumpPressed = false;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    private bool isFirePressed = false;

    float x = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player_1").GetComponent<Player>();
        Player2 = GameObject.Find("Player_2").GetComponent<Player>();

        Player1.AssignKeys(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.Space);
        Player2.AssignKeys(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.M);
    }

    // Update is called once per frame
    void Update()
    {


        // Player2.transform.position += new Vector3(0.1f, 0, 0);
        //Player2.transform.position += new Vector3(0.01f, 0, 0);

        //Player1.DoKeyEvents(KeyCode.UpArrow, Input.GetKeyDown(KeyCode.UpArrow));
        //Player1.DoKeyEvents(KeyCode.LeftArrow, Input.GetKeyDown(KeyCode.LeftArrow));
        //Player1.DoKeyEvents(KeyCode.RightArrow, Input.GetKeyDown(KeyCode.RightArrow));
        //Player1.DoKeyEvents(KeyCode.Space, Input.GetKeyDown(KeyCode.Space));

        //Player2.DoKeyEvents(KeyCode.UpArrow, Input.GetKeyDown(KeyCode.UpArrow));
        //Player2.DoKeyEvents(KeyCode.LeftArrow, Input.GetKeyDown(KeyCode.LeftArrow));
        //Player2.DoKeyEvents(KeyCode.RightArrow, Input.GetKeyDown(KeyCode.RightArrow));
        //Player2.DoKeyEvents(KeyCode.Space, Input.GetKeyDown(KeyCode.Space));

        //Player1.DoKeyEvents();
        //Player2.DoKeyEvents();
    }

    void GetInputs()
    {

    }
}
