using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float jiggleAmount = 1f;//magnitude of jiggle
    public float jiggleTime = 0.5f;//duration

    //player components
    public Rigidbody rb;
    private MaterialPropertyBlock materialBlock;
    private Renderer objectRenderer;
    private PlayerData playerData;
    private CameraShake cameraShake;

    private Controller controller;

    Color colourOriginal;//start colour of object
    Color colourSeverlyDamaged;//colour to fade towards
    Color colourCurrent;//actual variable that holds the current colour. This is the variable that is modified

    void Start()
    {
        //get components
        playerData = gameObject.GetComponent<PlayerData>();
        objectRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();

        //store original colour to be used when game is reset
        colourOriginal = objectRenderer.material.color;

        //severly-damaged colour
        colourSeverlyDamaged = Color.red;

        //the material that is changing colour
        materialBlock = new MaterialPropertyBlock();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if collision object is a bullet
        if(collision.gameObject.tag == "Bullet")
        {
            //reduce health
            playerData.health -= Bullet.damageAmount;

            //notify health bar
            playerData.healthBar.TakeDamage(Bullet.damageAmount);

            //do stuff for this player
            DoImHitVisuals(collision);

            //notify if player is dead
            if(playerData.health <= 0){
                controller.IamDead(gameObject);
            }
        }
    }
    protected void DoImHitVisuals(Collision collision)
    {
        //change colour according to health level
        colourCurrent = Color.Lerp(colourSeverlyDamaged, colourOriginal, playerData.health);
        materialBlock.SetColor("_Color", colourCurrent);
        objectRenderer.SetPropertyBlock(materialBlock);

        //jiggle the player
        Jiggle();

        //shake the camera
        cameraShake.PlayerHit();
    }

    protected void Jiggle()
    {
        //use iTween to jiggle player
        iTween.PunchScale(gameObject, new Vector3(jiggleAmount, jiggleAmount, jiggleAmount), jiggleTime);
    }
}
