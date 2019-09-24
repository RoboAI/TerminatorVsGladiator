using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public void SetText(string text)
    {
        Debug.Log("set text");
        //TextMesh textButton = transform.Find("ButtonTopScores").GetComponent<TextMesh>();
        //textButton.text = text;
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("ChangeScene");
        SceneManager.LoadScene(sceneName);
    }
}
