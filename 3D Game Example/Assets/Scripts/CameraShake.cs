using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool cameraShaking = false;
    private bool CamShake = false;
    private bool shakeCamera = false;
    private float ShakeDurationRemaining = 0f;
    public float shakeMagnitude = 0.25f;
    public float shakeDurationDefault = 0.25f;
    public float delayBetweenFrame = 0.01f;

    private void LateUpdate()
    {
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
}
