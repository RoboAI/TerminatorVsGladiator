using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Debug.Log("ChangeScene");
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Debug.Log("exit");
    }
}
