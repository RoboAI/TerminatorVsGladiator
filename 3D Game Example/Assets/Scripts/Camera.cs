using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Player player1;
    Player player2;

    float maxLeft = -1.95f;
    float maxRight = 1.95f;

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
        MoveToPlayer(player1);
    }

    private void FixedUpdate()
    {
        
    }

    void MoveToPlayer(Player player)
    {
        positionVector.Set(player1.transform.position.x, transform.position.y, transform.position.z);
        transform.position = positionVector;

        if(transform.position.x <= maxLeft)
        {
            positionVector.Set(maxLeft, transform.position.y, transform.position.z);
            transform.position = positionVector;
        }
        else if(transform.position.x >= maxRight)
        {
            positionVector.Set(maxRight, transform.position.y, transform.position.z);
            transform.position = positionVector;
        }

        //if (transform.position.x >= maxLeft && transform.position.x <= maxRight)
        //{
        //    positionVector.Set(player1.transform.position.x, transform.position.y, transform.position.z);
        //    transform.position = positionVector;
        //}


    }
}
