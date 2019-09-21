using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    Player Player1;
    Player Player2;

    public float multiplier = 200;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player_1").GetComponent<Player>();
        Player2 = GameObject.Find("Player_2").GetComponent<Player>();

        // Start is called before the first frame update
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("JJJJJJ");
            Rigidbody rb = Player2.GetComponent<Rigidbody>();
            rb.AddForceAtPosition(Vector3.right * multiplier, transform.position);
;        }
    }
}
