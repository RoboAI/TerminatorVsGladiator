using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float barLength = 0;
    private float healthBarRatio;

    Rigidbody rd;
    Renderer objectRenderer;
    public PlayerData playerData;//set by controller

    Mesh mesh;
    Vector3[] vertices;
    Vector3[] originalVertices;

    public bool iAmBarOnLeft = true;//set by Controller
    public Vector3 direction;

    private bool takeDamage = false;
    private float damageAmount = 0;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        playerData = GetComponent<PlayerData>();

        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        originalVertices = CreateNewVerticesCopy(vertices);

        barLength = Mathf.Abs(vertices[0].x - vertices[9].x) * transform.localScale.x;
        healthBarRatio = barLength / 100;
    }

    private void FixedUpdate()
    {
        if (takeDamage)
        {
            takeDamage = false;
            damageAmount = 0;

            vertices[0] += direction;
            vertices[2] += direction;
            vertices[4] += direction;
            vertices[6] += direction;
            vertices[8] += direction;
            vertices[10] += direction;
            vertices[12] += direction;
            vertices[13] += direction;
            vertices[20] += direction;
            vertices[21] += direction;
            vertices[22] += direction;
            vertices[23] += direction;

            mesh.vertices = vertices;
            mesh.RecalculateBounds();
        }
    }

    public void TakeDamage(float amount)
    {
        //Debug.Log("Take damage");

        damageAmount = amount;
        takeDamage = true;

        direction = Vector3.left * damageAmount;

        if (playerData.health <= 0)
        {
            //Debug.Log("health <= 0");

            ResetBar();
            playerData.health = 1.0f;
            return;
        }
    }

    public void ResetBar()
    {
        //Debug.Log("ResetBar");

        CopyVertices(originalVertices, vertices);
        mesh.vertices = originalVertices;
        mesh.RecalculateBounds();
    }

    public Vector3[] CreateNewVerticesCopy(Vector3[] src)
    {
        //Debug.Log("CreateNewVerticesCopy");

        Vector3[] dst = new Vector3[src.Length];
        for (int i = 0; i < src.Length; i++)
        {
            dst[i] = new Vector3(src[i].x, src[i].y, src[i].z);
        }
        return dst;
    }

    public void CopyVertices(Vector3[] src, Vector3[] dst)
    {
        //Debug.Log("CopyVertices");
        
        for (int i = 0; i < src.Length; i++)
        {
            dst[i].Set(src[i].x, src[i].y, src[i].z);
        }
    }
}
