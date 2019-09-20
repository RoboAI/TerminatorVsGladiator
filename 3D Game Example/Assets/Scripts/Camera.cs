using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Player player1;
    Player player2;

    float maxLeft = -7.2f;
    float maxRight = 7.2f;

    Vector3 positionVector = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player_1").GetComponent<Player>();
        player2 = GameObject.Find("Player_2").GetComponent<Player>();

        //positionVector = new Vector3(player1.transform.position.x, transform.position.y, transform.position.z);
        positionVector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        MoveToPlayer(player1);
    }

    void MoveToPlayer(Player player)
    {
        if (player1.transform.position.x >= -7.2f && player1.transform.position.x <= 7.2)
        {
            positionVector.Set(player1.transform.position.x, transform.position.y, transform.position.z);
            transform.position = positionVector;
        }

    }
}
