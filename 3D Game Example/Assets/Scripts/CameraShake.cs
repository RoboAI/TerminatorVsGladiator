using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool cameraShaking = false;//flag to break out of 'shaking' loop
    private bool CamShake = false;//flag to prevent anther shake while shaking
    private float ShakeDurationRemaining = 0f;//variable that's used to count down
    public float shakeMagnitude = 0.25f;//strength
    public float shakeDurationDefault = 0.25f;//this gets put into ShakeDurationRemaining at the start of a 'shake'

    private void LateUpdate()
    {
        //only shake if PlayerHit() called AND Camera-Not-shaking
        if (CamShake && !cameraShaking)
        {
            cameraShaking = true;
            StartCoroutine(ShakeCamera());
        }
    }

    //this is called from other classes to start a shake
    public void PlayerHit()
    {
        CamShake = true;
        cameraShaking = false;
    }


    IEnumerator ShakeCamera()
    {
        //store original position to position back once finished shaking
        Vector3 camInitial = transform.position;

        //assign a value to ShakeDurationRemaining to count down from
        ShakeDurationRemaining = shakeDurationDefault;

        while (CamShake)
        {
            if (ShakeDurationRemaining > 0)//if we still have time
            {
                //get random unit-posiiton, add to cam position then assign to actual camera's-position
                transform.position = camInitial + Random.insideUnitSphere * shakeMagnitude;
                
                //update 'remaining time'
                ShakeDurationRemaining -= Time.deltaTime;
            }
            else
            {
                //reset stuff

                CamShake = false;
                cameraShaking = false;
                transform.position = camInitial;
            }
            yield return null;
        }

        yield return null;
    }
}
