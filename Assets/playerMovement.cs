using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Called at consistent intervals (meant for physics)
    void FixedUpdate()
    {
        playerRB.AddForce(0, 0, 20);

        if( Input.GetKey("d"))
        {
            playerRB.AddForce(5, 0, 0);
        }
        
        if( Input.GetKey("a"))
        {
            playerRB.AddForce(-5, 0, 0);
        }

        if( Input.GetKey(KeyCode.Space))
        {
            playerRB.AddForce(0, 20, 0);
        } 
    }
}
