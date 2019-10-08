using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    public float maxLeft = -4f;
    public float maxRight = 4f;

    Vector3 positionVector = new Vector3();

    void Start()
    {
        player1 = GameObject.Find("PlayerMain1");
        player2 = GameObject.Find("PlayerMain2");

        positionVector = transform.position;
    }


    private void LateUpdate()
    {
        MoveToPlayer(player1);
    }


    void MoveToPlayer(GameObject player)
    {
        Vector3 player1Vec = player1.transform.position;
        Vector3 player2Vec = player2.transform.position;
        Vector3 middleVec = new Vector3(player1Vec.x + ((player2Vec.x - player1Vec.x) / 2), 4, transform.position.z);
        //float dist = ((player2Vec.x - player1Vec.x) / 2);
        
        positionVector.Set(middleVec.x, middleVec.y, middleVec.z);
        //positionVector.Set(player1.transform.position.x, transform.position.y, transform.position.z);
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
    }
}
