using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Player myPlayer;

    public void AssignPlayer(Player player)
    {
        myPlayer = player;
        PlaceShield();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    protected void PlaceShield()
    {
        transform.position = myPlayer.transform.position;
        Vector3 v = new Vector3();
    }
}
