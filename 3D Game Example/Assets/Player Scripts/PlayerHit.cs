using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float jiggleAmount = 1f;
    public float jiggleTime = 0.5f;

    public Rigidbody rb;
    private MaterialPropertyBlock materialBlock;
    private Renderer objectRenderer;
    private PlayerData playerData;
    private CameraShake camera;

    Color colourOriginal;
    Color colourSeverlyDamaged;
    Color colourCurrent;


    void Start()
    {
        playerData = gameObject.GetComponent<PlayerData>();
        objectRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraShake>();

        colourOriginal = objectRenderer.material.color;
        colourSeverlyDamaged = Color.red;

        materialBlock = new MaterialPropertyBlock();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
           // if(playerData.health <= 0)
            playerData.health -= Bullet.damageAmount;
            playerData.healthBar.TakeDamage(Bullet.damageAmount);
            ImHit(collision);
        }
    }
    protected void ImHit(Collision collision)
    {
        colourCurrent = Color.Lerp(colourSeverlyDamaged, colourOriginal, (playerData.health / 100));
        materialBlock.SetColor("_Color", colourCurrent);
        objectRenderer.SetPropertyBlock(materialBlock);

        Jiggle();
        camera.PlayerHit();
    }

    protected void Jiggle()
    {
        iTween.PunchScale(gameObject, new Vector3(jiggleAmount, jiggleAmount, jiggleAmount), jiggleTime);
    }
}
