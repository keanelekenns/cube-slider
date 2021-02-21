using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATE");
    }

    // Called at consistent intervals (meant for physics)
    void FixedUpdate()
    {
        playerRB.AddForce(0, -10, 50);
    }
}
