using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;
    HealthBar Player1_HealthBar;
    HealthBar Player2_HealthBar;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("PlayerMain1");
        Player2 = GameObject.Find("PlayerMain2");

        Player1_HealthBar = GameObject.Find("Player1_Health").GetComponent<HealthBar>();
        Player1_HealthBar.iAmBarOnLeft = true;
        Player1_HealthBar.playerData = Player1.GetComponent<PlayerData>();


       // Player1_HealthBar.health = Player1.GetComponent<PlayerData>().health;
        Player1.GetComponent<PlayerInputs>().AssignKeys(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.Space);
        Player1.GetComponent<PlayerInputMoves>().moveSpeed = Player1.GetComponent<PlayerData>().moveSpeed;
        Player1.GetComponent<PlayerData>().healthBar = Player1_HealthBar;

        Player2_HealthBar = GameObject.Find("Player2_Health").GetComponent<HealthBar>();
        Player2_HealthBar.iAmBarOnLeft = false;
        Player2_HealthBar.playerData = Player1.GetComponent<PlayerData>();
        // Player2_HealthBar.health = Player1.GetComponent<PlayerData>().health;
        Player2.GetComponent<PlayerInputs>().AssignKeys(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.KeypadEnter);
        Player2.GetComponent<PlayerInputMoves>().moveSpeed = Player2.GetComponent<PlayerData>().moveSpeed;
        Player2.GetComponent<PlayerData>().healthBar = Player2_HealthBar;

        //GameObject.Find("Quad").GetComponent<Shield>().AssignPlayer(Player1);
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
