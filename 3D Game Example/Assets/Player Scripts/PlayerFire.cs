using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFire : MonoBehaviour
{
    public Rigidbody rb;
    private PlayerInputs playerInputs;

    GameObject bulletOriginal;
    public float bulletSpeed = 3f;
    public float x_offset = 1.0f;
    public float y_vector = 2.5f;
    public float down_force = 8.0f;


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
            //instantiate bullet and set velocity
            CreateAndShoot(bulletOriginal, 0, gameObject);
        }
    }

    private void FixedUpdate()
    {
        //----------------------------------------------------------------------------------------/
        //Vector3 thisPlayerVector = gameObject.transform.position;
        //Vector3 otherPlayerVector = GetOtherPlayer(gameObject).transform.position;

        //Vector3 bulletFinalVector = (thisPlayerVector - otherPlayerVector);
        //bulletFinalVector.y = 0;
        //bulletFinalVector.Normalize();
        //bulletFinalVector *= -1;//'z' axis may not need to be inverted??

        //string s = rb.velocity.x.ToString() + "\n" + rb.velocity.y.ToString() + "\n" + rb.velocity.z.ToString();
        //string s = bulletFinalVector.x.ToString() + "\n" + bulletFinalVector.y.ToString() + "\n" + bulletFinalVector.z.ToString();
        //GameObject.Find("TextTemp").GetComponent<TextMeshProUGUI>().SetText(s);
        //----------------------------------------------------------------------------------------/
    }

    public void CreateAndShoot(GameObject bullet, int layer, GameObject playerRequestingShoot/*not used*/)
    {
        //Debug.Log("CreateAndShoot");
        Vector3 playerTransform = rb.transform.position;

        //clone 'reference bullet'
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody instRB = instBullet.GetComponent<Rigidbody>();

        instBullet.name = "Bullet";
        instBullet.tag = "Bullet";//used for collisions
        instBullet.layer = GetOtherPlayer(playerRequestingShoot).layer;
        instRB.useGravity = true;

        instBullet.AddComponent<Bullet>();
        instBullet.GetComponent<ConstantForce>().force = Vector3.down * down_force;

        Vector3 bulletDirection = GetBulletNormalisedDirection();

        instBullet.transform.position = new Vector3(playerTransform.x + (bulletDirection.x * x_offset), playerTransform.y + 0.25f, playerTransform.z);

        bulletDirection.x *= bulletSpeed;
        bulletDirection.y += y_vector;
        bulletDirection.z = 0;

        //fire
        instRB.AddForce(bulletDirection, ForceMode.Impulse);

        instBullet.GetComponent<SphereCollider>().enabled = true;
    }

    GameObject GetOtherPlayer(GameObject player)
    {
        GameObject go1 = GameObject.Find("PlayerMain1");
        GameObject go2 = GameObject.Find("PlayerMain2");

        return (player.name == go1.name) ? go2 : go1;
    }

    Vector3 GetBulletNormalisedDirection()
    {
        Vector3 thisPlayerVector = gameObject.transform.position;
        Vector3 otherPlayerVector = GetOtherPlayer(gameObject).transform.position;

        Vector3 bulletFinalVector = (thisPlayerVector - otherPlayerVector);
        bulletFinalVector.y = 0;
        bulletFinalVector.Normalize();
        bulletFinalVector *= -1;//'z' axis may not need to be inverted??

        //string s = bulletFinalVector.x.ToString() + "\n" + bulletFinalVector.y.ToString() + "\n" + bulletFinalVector.z.ToString();
        //GameObject.Find("TextTemp").GetComponent<TextMeshProUGUI>().SetText(s);

        //return new Vector3(bulletFinalVector.x, bulletFinalVector.y * -1, 0);
        //return new Vector3(-bulletFinalVector.x * bulletSpeed, y_vector, 0);
        return bulletFinalVector;
    }
}
