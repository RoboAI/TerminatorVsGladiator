using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    public float maxLeft = -4f;
    public float maxRight = 4f;

    Vector3 positionVector = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("PlayerMain1");
        player2 = GameObject.Find("PlayerMain2");

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

    void MoveToPlayer(GameObject player)
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
