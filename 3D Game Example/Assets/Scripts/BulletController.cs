using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameObject bullet;
    public float speed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.Find("BulletMain");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateAndShoot(bullet);
        }
    }

    public void CreateAndShoot(GameObject bullet)
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        instBullet.name = "Bullet";
        instBullet.layer = 9;
        //instBullet.tag = "BulletPlayer1";
        instBullet.AddComponent<Bullet>();
        instBullet.GetComponent<Collider>().enabled = true;
        instBullet.GetComponent<Rigidbody>().useGravity = true;
        instBullet.transform.position += new Vector3(3, 0, 0);
        Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidBody.AddForce(new Vector3(100, 50, 0), ForceMode.Impulse);
       // instBulletRigidBody.AddForce(new Vector3(100, -500, 0), ForceMode.Acceleration);
    }
}
