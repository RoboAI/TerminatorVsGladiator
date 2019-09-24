using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Rigidbody rb;
    private PlayerInputs playerInputs;

    GameObject bulletOriginal;
    public float bulletSpeed = 1f;
    public float x_offset = 1;
    public float y_vector = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInputs>();
        bulletOriginal = GameObject.Find("BulletMain");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputs.isFirePressed)
        {
            CreateAndShoot(bulletOriginal, 9, gameObject);
        }
    }

    private void FixedUpdate()
    {

    }

    public void CreateAndShoot(GameObject bullet, int layer, GameObject playerRequestingShoot/*not used*/)
    {
        //Debug.Log("CreateAndShoot");
        Vector3 playerTransform = rb.transform.position;

        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody instRB = instBullet.GetComponent<Rigidbody>();

        instBullet.name = "Bullet";
        instBullet.tag = "Bullet";
        instBullet.layer = layer;
        instRB.useGravity = true;

        instBullet.AddComponent<Bullet>();
        instBullet.GetComponent<Collider>().enabled = true;
        instBullet.GetComponent<ConstantForce>().force = Vector3.down * 10;
        instBullet.transform.position = new Vector3(playerTransform.x + x_offset, playerTransform.y, playerTransform.z);

        instRB.AddForce(new Vector3(bulletSpeed, y_vector, 0), ForceMode.Impulse);
    }
}
