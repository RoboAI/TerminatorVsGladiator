using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndedImage : MonoBehaviour
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
