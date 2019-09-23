using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCube : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    //public int i = 0;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
    }

    void Update()
    {
        /*
        for (var i = 0; i < vertices.Length; i++)
        {
            if(vertices[i] == Vector3.right)
                vertices[i] += Vector3.right * Time.deltaTime;
            //vertices[0] += Vector3.right * Time.deltaTime;
            //vertices[1] += Vector3.right * Time.deltaTime;
            //vertices[2] += Vector3.right * Time.deltaTime;
            //vertices[3] += Vector3.right * Time.deltaTime;
            //vertices[i] += Vector3.right * Time.deltaTime;

            //vertices[4] += Vector3.right * Time.deltaTime;
            //vertices[6] += Vector3.right * Time.deltaTime;
            //vertices[0] += Vector3.right * Time.deltaTime;
            //vertices[3] += Vector3.right * Time.deltaTime;
        }
        */

        int j = 0;

        if (Input.GetKey(KeyCode.I))
        {
            j = 0;
        }
        if (Input.GetKey(KeyCode.O))
        {
            j = 10;
        }
        if (Input.GetKey(KeyCode.P))
        {
            j = 20;
        }

        if (Input.GetKey(KeyCode.Alpha0))
        {
            vertices[j + 0] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            vertices[j + 1] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            vertices[j + 2] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            vertices[j + 3] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            vertices[j + 4] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            vertices[j + 5] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            vertices[j + 6] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            vertices[j + 7] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            vertices[j + 8] += Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            vertices[j + 9] += Vector3.right * Time.deltaTime;
        }

        //vertices[0] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[2] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[4] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[6] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[8] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[10] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[12] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[13] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[20] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[21] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[22] -= Vector3.right * Time.deltaTime * 0.1f;
        //vertices[23] -= Vector3.right * Time.deltaTime * 0.1f;

        //4, 6, 8, 10, 12, 13, 20, 21, 22, 23

        // assign the local vertices array into the vertices array of the Mesh.
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
}
