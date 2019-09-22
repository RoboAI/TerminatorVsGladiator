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
    public float y_vector = 5;


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
            Debug.Log("shooting");
;            CreateAndShoot(bulletOriginal, gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void CreateAndShoot(GameObject bullet, GameObject playerRequestingShoot/*not used*/)
    {
        Vector3 playerTransform = rb.transform.position;

        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        instBullet.name = "Bullet";
        instBullet.layer = 9;
        //instBullet.tag = "BulletPlayer1";
        instBullet.AddComponent<Bullet>();
        instBullet.GetComponent<Collider>().enabled = true;
        instBullet.GetComponent<Rigidbody>().useGravity = true;
        instBullet.GetComponent<ConstantForce>().force = Vector3.down * 10;
        instBullet.transform.position = new Vector3(playerTransform.x + x_offset, playerTransform.y + 0.5f, playerTransform.z);
        Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();

        
        instBulletRigidBody.AddForce(new Vector3(bulletSpeed, y_vector, 0), ForceMode.Impulse);
        // instBulletRigidBody.AddForce(new Vector3(100, -500, 0), ForceMode.Acceleration);
    }
}
