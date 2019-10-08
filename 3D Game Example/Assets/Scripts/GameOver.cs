using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void Hide()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //gameObject.SetActive(false);
    }

    public void Show()
    {
        //gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
