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

    private bool cameraShaking = false;
    private bool CamShake = false;
    private bool shakeCamera = false;
    private float ShakeDurationRemaining = 0f;
    public float shakeMagnitude = 0.25f;
    public float shakeDurationDefault = 0.25f;
    public float delayBetweenFrame = 0.01f;

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

    private void LateUpdate()
    {
        MoveToPlayer(player1);

        if (CamShake && !cameraShaking)
        {
            cameraShaking = true;
            StartCoroutine(ShakeCamera());
        }
    }

    public void PlayerHit()
    {
        CamShake = true;
        cameraShaking = false;
    }

    IEnumerator ShakeCamera()
    {
        Vector3 camInitial = transform.position;

        ShakeDurationRemaining = shakeDurationDefault;

        while (CamShake)
        {
            if (ShakeDurationRemaining > 0)
            {
                transform.position = camInitial + Random.insideUnitSphere * shakeMagnitude;
                ShakeDurationRemaining -= Time.deltaTime;
            }
            else
            {
                CamShake = false;
                cameraShaking = false;
                transform.position = camInitial;
            }
            yield return null;
        }

        yield return null;
    }

    public void OnShakeComplete()
    {
        
    }

    //void ShakeCamera()
    //{
    //    //iTween.MoveBy(gameObject, iTween.Hash("x", 2, 
    //    //                                    "easeType", "easeInOutExpo", 
    //    //                                    "loopType", "pingPong",
    //    //                                    "oncomplete", "OnShakeComplete",
    //    //                                    "delay", 1));

    //    //iTween.MoveTo(gameObject, iTween.Hash("x", 2, "oncomplete", "something", "oncompletetarget", this.gameObject));

    //}

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
