using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
        //iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 0.01));
        
    }

    void DoPulse()
    {
        iTween.Stop();
        System.Collections.Hashtable hash =
                   new System.Collections.Hashtable();
        hash.Add("amount", new Vector3(2f, 2f, 2f));
        hash.Add("time", 0.25f);
        iTween.PunchScale(gameObject, hash);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DoPulse();
    }


}

